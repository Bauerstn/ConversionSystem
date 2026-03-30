using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.RequestModels;

namespace ConversionSystem.Service.Contracts.Interfaces
{
    public interface IReportResultService
    {
        /// <summary>
        /// Получить список всех <see cref="ReportResultModel"/>
        /// </summary>
        Task<IEnumerable<ReportResultModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ReportResultModel"/> по идентификатору
        /// </summary>
        Task<ReportResultModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ReportResultModel"/> по идентификатору продукта, по идентификатору оформления, периода
        /// </summary>
        Task<ReportResultModel> GetByProductIdAndPresentationIdAsync(Guid productId, Guid presentationId, DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового <see cref="ReportResultModel"/>
        /// </summary>
        Task<ReportResultModel> AddAsync(ReportResultRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующую <see cref="ProductModel"/>
        /// </summary>
        Task<ReportResultModel> EditAsync(ReportResultRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего <see cref="ReportResultModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
