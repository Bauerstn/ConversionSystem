namespace ConversionSystem.Context.Contracts.Models
{
    /// <summary>
    /// Сущность результата отчета
    /// </summary>
    public class ReportResult : BaseAuditEntity
    {
        /// <summary>
        /// Идентификатор <inheritdoc cref="ProductPresentation"/>
        /// </summary>
        public Guid ProductPresentationId { get; set; }

        /// <summary>
        /// Оформление товара
        /// </summary>
        public ProductPresentation ProductPresentation { get; set; }

        /// <summary>
        /// Рацио просмотров/оплат
        /// </summary>
        public decimal ViewToPaymentRatio { get; set; }
    }
}
