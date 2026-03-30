namespace ConversionSystem.Service.Contracts.Models
{
    /// <summary>
    /// Модель товара
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Количество покупок
        /// </summary>
        public int ProductCount { get; set; }
    }
}
