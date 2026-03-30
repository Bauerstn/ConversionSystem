using ConversionSystem.API.Models.Enums;

namespace ConversionSystem.API.Models
{
    /// <summary>
    /// Модель ответа сущности товара в оформлении
    /// </summary>
    public class ProductPresentationResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="ProductResponse"/>
        /// </summary>
        public ProductResponse? Product { get; set; }

        /// <summary>
        /// <inheritdoc cref="PresentationTypesResponse"/>
        /// </summary>
        public PresentationTypesResponse PresentationType { get; set; } = PresentationTypesResponse.CartInCataloge;

        /// <summary>
        /// Количество просмотров
        /// </summary>
        public int ViewCount { get; set; }
    }
}
