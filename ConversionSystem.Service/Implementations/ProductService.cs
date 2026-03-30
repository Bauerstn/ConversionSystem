using AutoMapper;
using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.Exceptions;
using ConversionSystem.Service.Contracts.Interfaces;
using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.RequestModels;

namespace ConversionSystem.Service.Implementations
{
    public class ProductService : IProductService, IServiceAnchor
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<ProductModel>> IProductService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await productReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ProductModel>>(result);
        }

        async Task<ProductModel> IProductService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await productReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new ConversionEntityNotFoundException<Product>(id);
            }

            return mapper.Map<ProductModel>(item);
        }

        async Task<ProductModel> IProductService.AddAsync(ProductRequestModel request, CancellationToken cancellationToken)
        {
            var item = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ProductCount = request.ProductCount,
            };

            productWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ProductModel>(item);
        }

        async Task<ProductModel> IProductService.EditAsync(ProductRequestModel source, CancellationToken cancellationToken)
        {
            var target = await productReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (target == null)
            {
                throw new ConversionEntityNotFoundException<Product>(source.Id);
            }

            target.Name = source.Name.Trim();
            target.ProductCount = source.ProductCount;

            productWriteRepository.Update(target);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ProductModel>(target);
        }

        async Task IProductService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var target = await productReadRepository.GetByIdAsync(id, cancellationToken);
            if (target == null)
            {
                throw new ConversionEntityNotFoundException<Product>(id);
            }

            productWriteRepository.Delete(target);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}