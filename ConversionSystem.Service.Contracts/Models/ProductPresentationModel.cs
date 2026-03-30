using ConversionSystem.Service.Contracts.Models.Enums;

namespace ConversionSystem.Service.Contracts.Models
{
    /// <summary>
    /// Модель товара в оформлении
    /// </summary>
    public class ProductPresentationModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="ProductModel"/>
        /// </summary>
        public ProductModel Product { get; set; }

        /// <summary>
        /// <inheritdoc cref="PresentationTypesModel"/>
        /// </summary>
        public PresentationTypesModel PresentationType { get; set; }

        /// <summary>
        /// Количество просмотров
        /// </summary>
        public int ViewCount { get; set; }
    }
}