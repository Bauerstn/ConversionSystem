using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionSystem.Service.Contracts.RequestModels
{
    /// <summary>
    /// Модель запроса товара в оформлении
    /// </summary>
    public class ProductPresentationRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="ProductModel"/>
        /// </summary>
        public Guid ProductId { get; set; }

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
