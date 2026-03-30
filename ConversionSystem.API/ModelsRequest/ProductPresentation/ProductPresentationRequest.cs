namespace ConversionSystem.API.ModelsRequest.ProductPresentation
{
    /// <summary>
    /// Модель запроса редактирования товара в оформлении
    /// </summary>
    public class ProductPresentationRequest : CreateProductPresentationRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
