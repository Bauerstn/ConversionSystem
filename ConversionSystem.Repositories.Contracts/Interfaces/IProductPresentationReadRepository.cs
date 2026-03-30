using ConversionSystem.Context.Contracts.Enums;
using ConversionSystem.Context.Contracts.Models;

namespace ConversionSystem.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="ProductPresentation"/>
    /// </summary>
    public interface IProductPresentationReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="ProductPresentation"/>
        /// </summary>
        Task<IReadOnlyCollection<ProductPresentation>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ProductPresentation"/> по идентификатору
        /// </summary>
        Task<ProductPresentation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="ProductPresentation"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, ProductPresentation>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ProductPresentation"/> по идентификатору продукта и типу оформления
        /// </summary>
        Task<ProductPresentation?> GetByProductIdAndPresentationTypeAsync(Guid productId, PresentationTypes presentationType, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="ProductPresentation"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
