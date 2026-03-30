using ConversionSystem.Service.Contracts.Models;

namespace ConversionSystem.API.ModelsRequest.ReportResult
{
    /// <summary>
    /// Модель запроса создания результата отчета
    /// </summary>
    public class CreateReportResultRequest
    {
        /// <summary>
        /// <inheritdoc cref="ProductPresentationModel"/>
        /// </summary>
        public Guid ProductPresentationId { get; set; }
    }
}
