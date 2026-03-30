namespace ConversionSystem.Service.Contracts.RequestModels
{
    /// <summary>
    /// Модель запроса товара
    /// </summary>
    public class ProductRequestModel
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
