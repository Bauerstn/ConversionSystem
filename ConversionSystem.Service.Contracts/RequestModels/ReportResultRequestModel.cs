using ConversionSystem.Service.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionSystem.Service.Contracts.RequestModels
{
    /// <summary>
    /// Модель запроса результат отчета
    /// </summary>
    public class ReportResultRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="ProductPresentationModel"/>
        /// </summary>
        public Guid ProductPresentationId { get; set; }

        /// <summary>
        /// Рацио просмотров/оплат
        /// </summary>
        public decimal ViewToPaymentRatio { get; set; }
    }
}
