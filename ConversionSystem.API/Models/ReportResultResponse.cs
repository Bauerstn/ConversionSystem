namespace ConversionSystem.API.Models
{
    /// <summary>
    /// Модель ответа результата отчета
    /// </summary>
    public class ReportResultResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="ProductPresentationResponse"/>
        /// </summary>
        public ProductPresentationResponse? ProductPresentation { get; set; }

        /// <summary>
        /// Рацио просмотров/оплат
        /// </summary>
        public decimal ViewToPaymentRatio { get; set; }
    }
}
