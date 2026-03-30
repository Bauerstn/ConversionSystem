using ConversionSystem.API.Models.Enums;
using ConversionSystem.Service.Contracts.Models;

namespace ConversionSystem.API.ModelsRequest.ProductPresentation
{
    /// <summary>
    /// Модель запроса создания товара в оформлении
    /// </summary>
    public class CreateProductPresentationRequest
    {
        /// <summary>
        /// <inheritdoc cref="ProductModel"/>
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// <inheritdoc cref="PresentationTypesResponse"/>
        /// </summary>
        public PresentationTypesResponse PresentationType { get; set; }

        /// <summary>
        /// Количество просмотров
        /// </summary>
        public int ViewCount { get; set; }
    }
}
