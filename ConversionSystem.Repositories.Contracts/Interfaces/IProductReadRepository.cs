using ConversionSystem.Context.Contracts.Models;

namespace ConversionSystem.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий чтения <see cref="Product"/>
    /// </summary>
    public interface IProductReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Product"/>
        /// </summary>
        Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Product"/> по идентификатору
        /// </summary>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Product"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Product>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка есть ли <see cref="Product"/> по указанному id
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
