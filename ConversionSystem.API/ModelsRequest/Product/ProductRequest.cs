namespace ConversionSystem.API.ModelsRequest.Product
{
    /// <summary>
    /// Модель запроса редактирования товаара
    /// </summary>
    public class ProductRequest : CreateProductRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
