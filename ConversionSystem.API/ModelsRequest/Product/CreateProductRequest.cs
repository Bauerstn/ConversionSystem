namespace ConversionSystem.API.ModelsRequest.Product
{
    /// <summary>
    /// Модель запроса создания товара
    /// </summary>
    public class CreateProductRequest
    {
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
