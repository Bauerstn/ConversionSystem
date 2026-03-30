using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Common.Entity.Repositories;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConversionSystem.Repositories.Implementations
{
    public class ReportResultReadRepository : IReportResultReadRepository, IRepositoryAnchor
    {
        private IDbReader reader;

        public ReportResultReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<ReportResult>> IReportResultReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<ReportResult>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<ReportResult?> IReportResultReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<ReportResult>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<ReportResult?> IReportResultReadRepository.GetByProductIdAndPresentationIdAsync(Guid productId, Guid presentationId, DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken)
            => reader.Read<ReportResult>()
                .NotDeletedAt()
                .Where(x => x.ProductPresentation.ProductId == productId)
                .Where(x => x.ProductPresentationId == presentationId)
                .Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
