using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.RequestModels;

namespace ConversionSystem.Service.Contracts.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Получить список всех <see cref="ProductModel"/>
        /// </summary>
        Task<IEnumerable<ProductModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ProductModel"/> по идентификатору
        /// </summary>
        Task<ProductModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового <see cref="ProductModel"/>
        /// </summary>
        Task<ProductModel> AddAsync(ProductRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующую <see cref="ProductModel"/>
        /// </summary>
        Task<ProductModel> EditAsync(ProductRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего <see cref="ProductModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
