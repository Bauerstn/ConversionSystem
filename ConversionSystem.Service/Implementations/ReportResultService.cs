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
    public class ReportResultService : IReportResultService, IServiceAnchor
    {
        private readonly IReportResultReadRepository reportResultReadRepository;
        private readonly IReportResultWriteRepository reportResultWriteRepository;
        private readonly IProductPresentationReadRepository productPresentationReadRepository;
        private readonly IProductReadRepository productReadRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReportResultService(IReportResultReadRepository reportResultReadRepository,
            IReportResultWriteRepository reportResultWriteRepository,
            IProductPresentationReadRepository productPresentationReadRepository,
            IProductReadRepository productReadRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.reportResultReadRepository = reportResultReadRepository;
            this.reportResultWriteRepository = reportResultWriteRepository;
            this.productPresentationReadRepository = productPresentationReadRepository;
            this.productReadRepository = productReadRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<ReportResultModel>> IReportResultService.GetAllAsync(CancellationToken cancellationToken)
        {
            var reportResults = await reportResultReadRepository.GetAllAsync(cancellationToken);

            var productPresentationId = reportResults.Select(x => x.ProductPresentationId).Distinct();
            var productId = reportResults.Select(x => x.ProductPresentation.ProductId).Distinct();

            var productPresentations = await productPresentationReadRepository.GetByIdsAsync(productPresentationId, cancellationToken);
            var products = await productReadRepository.GetByIdsAsync(productId, cancellationToken);

            var reportResultsModels = new List<ReportResultModel>();
            foreach(var reportResult in reportResults)
            {
                if (!productPresentations.TryGetValue(reportResult.ProductPresentationId, out var productPresentation)) continue;
                if (!products.TryGetValue(reportResult.ProductPresentation.ProductId, out var product)) continue;

                var reportResultItem = mapper.Map<ReportResultModel>(reportResult);
                reportResultItem.ProductPresentation = mapper.Map<ProductPresentationModel>(productPresentation);
                reportResultItem.ProductPresentation.Product = mapper.Map<ProductModel>(product);

                reportResultsModels.Add(reportResultItem);
            }
            return reportResultsModels;
        }

        async Task<ReportResultModel> IReportResultService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await reportResultReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new ConversionEntityNotFoundException<ReportResult>(id);
            }

            var productPresentation = await productPresentationReadRepository.GetByIdAsync(item.ProductPresentationId, cancellationToken);
            if (productPresentation == null)
            {
                throw new ConversionEntityNotFoundException<ProductPresentation>(item.ProductPresentationId);
            }

            var product = await productReadRepository.GetByIdAsync(productPresentation.ProductId, cancellationToken);
            if (product == null)
            {
                throw new ConversionEntityNotFoundException<Product>(productPresentation.ProductId);
            }

            var reportResult = mapper.Map<ReportResultModel>(item);

            reportResult.ProductPresentation = mapper.Map<ProductPresentationModel>(productPresentation);
            reportResult.ProductPresentation.Product = mapper.Map<ProductModel>(product);
            return reportResult;
        }

        async Task<ReportResultModel> IReportResultService.GetByProductIdAndPresentationIdAsync(Guid productId, Guid presentationId, DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken)
        {
            var item = await reportResultReadRepository.GetByProductIdAndPresentationIdAsync(productId, presentationId, startDate, endDate, cancellationToken);
            if (item == null)
            {
                throw new ConversionNotFoundException("Отчет с заданными параметрами не найден.");
            }

            var productPresentation = await productPresentationReadRepository.GetByIdAsync(item.ProductPresentationId, cancellationToken);
            if (productPresentation == null)
            {
                throw new ConversionEntityNotFoundException<ProductPresentation>(item.ProductPresentationId);
            }

            var product = await productReadRepository.GetByIdAsync(productPresentation.ProductId, cancellationToken);
            if (product == null)
            {
                throw new ConversionEntityNotFoundException<Product>(productPresentation.ProductId);
            }

            var reportResult = mapper.Map<ReportResultModel>(item);

            reportResult.ProductPresentation = mapper.Map<ProductPresentationModel>(productPresentation);
            reportResult.ProductPresentation.Product = mapper.Map<ProductModel>(product);
            return reportResult;
        }

        async Task<ReportResultModel> IReportResultService.AddAsync(ReportResultRequestModel request, CancellationToken cancellationToken)
        {
            var productPresentation = await productPresentationReadRepository.GetByIdAsync(request.ProductPresentationId, cancellationToken);
            if(productPresentation == null)
            {
                throw new ConversionEntityNotFoundException<ProductPresentation>(request.ProductPresentationId);
            }

            var product = await productReadRepository.GetByIdAsync(productPresentation.ProductId, cancellationToken);
            if(product == null)
            {
                throw new ConversionEntityNotFoundException<Product>(productPresentation.ProductId);
            }

            var item = new ReportResult
            {
                Id = Guid.NewGuid(),
                ProductPresentationId = productPresentation.Id,
                ViewToPaymentRatio = (decimal)product.ProductCount / productPresentation.ViewCount
            };
            reportResultWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ReportResultModel>(item);
        }

        async Task<ReportResultModel> IReportResultService.EditAsync(ReportResultRequestModel source, CancellationToken cancellationToken)
        {
            var target = await reportResultReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (target == null)
            {
                throw new ConversionEntityNotFoundException<ReportResult>(source.Id);
            }

            var productPresentation = await productPresentationReadRepository.GetByIdAsync(source.ProductPresentationId, cancellationToken);
            if (productPresentation == null)
            {
                throw new ConversionEntityNotFoundException<ProductPresentation>(source.ProductPresentationId);
            }

            var product = await productReadRepository.GetByIdAsync(productPresentation.ProductId, cancellationToken);
            if (product == null)
            {
                throw new ConversionEntityNotFoundException<Product>(productPresentation.ProductId);
            }

            target.ProductPresentationId = productPresentation.Id;
            target.ProductPresentation = productPresentation;
            target.ViewToPaymentRatio = (decimal)product.ProductCount / productPresentation.ViewCount;

            reportResultWriteRepository.Update(target);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ReportResultModel>(target);
        }

        async Task IReportResultService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var target = await reportResultReadRepository.GetByIdAsync(id, cancellationToken);
            if (target == null)
            {
                throw new ConversionEntityNotFoundException<ReportResult>(id);
            }

            reportResultWriteRepository.Delete(target);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
