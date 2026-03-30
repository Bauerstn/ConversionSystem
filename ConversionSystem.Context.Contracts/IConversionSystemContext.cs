using ConversionSystem.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace ConversionSystem.Context.Contracts
{
    /// <summary>
    /// Контекст работы с сущностями
    /// </summary>
    public interface IConversionSystemContext
    {
        /// <summary>Список <inheritdoc cref="Product"/></summary>
        DbSet<Product> Products { get; }

        /// <summary>Список <inheritdoc cref="ProductPresentation"/></summary>
        DbSet<ProductPresentation> ProductPresentations { get; }

        /// <summary>Список <inheritdoc cref="ReportResult"/></summary>
        DbSet<ReportResult> ReportResults { get; }
    }
}
