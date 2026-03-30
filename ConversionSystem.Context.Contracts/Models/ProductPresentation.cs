using ConversionSystem.Context.Contracts.Enums;

namespace ConversionSystem.Context.Contracts.Models
{
    /// <summary>
    /// Сущность товара в оформлении
    /// </summary>
    public class ProductPresentation : BaseAuditEntity
    {
        /// <summary>
        /// Идентификатор <inheritdoc cref="Product"/>
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Тип оформления
        /// </summary>
        public PresentationTypes PresentationType { get; set; } = PresentationTypes.CartInCataloge;

        /// <summary>
        /// Количество просмотров
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="ProductPresentation"/>
        /// </summary>
        public ICollection<ReportResult> ReportResult { get; set; }
    }
}