using AutoMapper;
using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context.Contracts.Enums;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.Exceptions;
using ConversionSystem.Service.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.RequestModels;

namespace ConversionSystem.Service.Implementations
{
    public class ProductPresentationService : IProductPresentationService, IServiceAnchor
    {
        private readonly IProductPresentationReadRepository productPresentationReadRepository;
        private readonly IProductPresentationWriteRepository productPresentationWriteRepository;
        private readonly IProductReadRepository productReadRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductPresentationService(IProductPresentationReadRepository productPresentationReadRepository,
            IProductPresentationWriteRepository productPresentationWriteRepository,
            IProductReadRepository productReadRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.productPresentationReadRepository = productPresentationReadRepository;
            this.productPresentationWriteRepository = productPresentationWriteRepository;
            this.productReadRepository = productReadRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<ProductPresentationModel>> IProductPresentationService.GetAllAsync(CancellationToken cancellationToken)
        {
            var presentationProducts = await productPresentationReadRepository.GetAllAsync(cancellationToken);
            var products = await productReadRepository.GetByIdsAsync(presentationProducts.Select(x => x.ProductId).Distinct(), cancellationToken);

            var result = new List<ProductPresentationModel>();
            foreach (var presentationProduct in presentationProducts)
            {
                if (!products.TryGetValue(presentationProduct.ProductId, out var product)) continue;
                var fl = mapper.Map<ProductPresentationModel>(presentationProduct);
                fl.Product = mapper.Map<ProductModel>(product);
                result.Add(fl);
            }

            return result;
        }

        async Task<ProductPresentationModel> IProductPresentationService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await productPresentationReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new ConversionEntityNotFoundException<ProductPresentation>(id);
            }
            var product = await productReadRepository.GetByIdAsync(item.ProductId, cancellationToken);
            var presentationProduct = mapper.Map<ProductPresentationModel>(item);
            presentationProduct.Product = mapper.Map<ProductModel>(product);
            return presentationProduct;
        }

        async Task<ProductPresentationModel> IProductPresentationService.AddAsync(ProductPresentationRequestModel request, CancellationToken cancellationToken)
        {
            var existProduct = await productReadRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (existProduct == null)
            {
                throw new ConversionEntityNotFoundException<Product>(request.ProductId);
            }
            
            var existProductPresentation = productPresentationReadRepository.GetByProductIdAndPresentationTypeAsync(request.ProductId, (PresentationTypes)request.PresentationType, cancellationToken);
            if (existProductPresentation != null)
            {
                throw new ConversionInvalidOperationException($"Товар с таким оформлением уже существует.");
            }

            var item = new ProductPresentation
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                PresentationType = (PresentationTypes)request.PresentationType,
                ViewCount = request.ViewCount
            };

            productPresentationWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ProductPresentationModel>(item);
        }

        async Task<ProductPresentationModel> IProductPresentationService.EditAsync(ProductPresentationRequestModel source, CancellationToken cancellationToken)
        {
            var target = await productPresentationReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (target == null)
            {
                throw new ConversionEntityNotFoundException<ProductPresentation>(source.Id);
            }

            target.PresentationType = (PresentationTypes)source.PresentationType;
            target.ViewCount = source.ViewCount;

            var product = await productReadRepository.GetByIdAsync(source.ProductId, cancellationToken);
            target.ProductId = product!.Id;
            target.Product = product;

            productPresentationWriteRepository.Update(target);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ProductPresentationModel>(target);
        }

        async Task IProductPresentationService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var target = await productPresentationReadRepository.GetByIdAsync(id, cancellationToken);
            if (target == null)
            {
                throw new ConversionEntityNotFoundException<ProductPresentation>(id);
            }

            productPresentationWriteRepository.Delete(target);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
