using ConversionSystem.Context.Contracts.Models;

namespace ConversionSystem.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="ReportResult"/>
    /// </summary>
    public interface IReportResultReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="ReportResult"/>
        /// </summary>
        Task<IReadOnlyCollection<ReportResult>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ReportResult"/> по идентификатору
        /// </summary>
        Task<ReportResult?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ReportResult"/> по идентификатору продукта, по идентификатору оформления, периода
        /// </summary>
        Task<ReportResult?> GetByProductIdAndPresentationIdAsync(Guid productId, Guid presentationId, DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken);
    }
}
