namespace ConversionSystem.Service.Contracts.Models
{
    /// <summary>
    /// Модель результата отчета
    /// </summary>
    public class ReportResultModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="ProductPresentationModel"/>
        /// </summary>
        public ProductPresentationModel ProductPresentation { get; set; }

        /// <summary>
        /// Рацио просмотров/оплат
        /// </summary>
        public decimal ViewToPaymentRatio { get; set; }
    }
}
