using System.ComponentModel;

namespace ConversionSystem.API.Infrastructures.Models.Enums
{
    /// <summary>
    /// Типы оформления
    /// </summary>
    public enum PresentationTypesResponse
    {
        /// <summary>
        /// В каталоге
        /// </summary>
        [Description("В каталоге")]
        CartInCataloge,

        /// <summary>
        /// Баннер
        /// </summary>
        [Description("Баннер")]
        Banner,

        /// <summary>
        /// Рекомендации
        /// </summary>
        [Description("Рекомендации")]
        Recomendation,

        /// <summary>
        /// Покупают вместе
        /// </summary>
        [Description("Покупают вместе")]
        BuyWith,

        /// <summary>
        /// Реклама
        /// </summary>
        [Description("Реклама")]
        Ad
    }
}
