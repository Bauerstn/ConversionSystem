namespace ConversionSystem.API.Models
{
    /// <summary>
    /// Модель ответа сущности товара
    /// </summary>
    public class ProductResponse
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
