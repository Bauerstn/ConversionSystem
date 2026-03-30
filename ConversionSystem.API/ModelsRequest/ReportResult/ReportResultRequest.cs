namespace ConversionSystem.API.ModelsRequest.ReportResult
{
    /// <summary>
    /// Модель запроса редактирования результата отчета
    /// </summary>
    public class ReportResultRequest : CreateReportResultRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
