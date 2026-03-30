namespace ConversionSystem.Context.Contracts.Models
{
    /// <summary>
    /// Сущность товара
    /// </summary>
    public class Product : BaseAuditEntity
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Количество покупок
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Коллекция для связи один ко многим по вторичному ключу <see cref="ProductPresentation"/>
        /// </summary>
        public ICollection<ProductPresentation> ProductPresentation { get; set; }
    }
}
