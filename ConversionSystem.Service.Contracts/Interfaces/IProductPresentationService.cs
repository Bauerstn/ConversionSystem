using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.RequestModels;

namespace ConversionSystem.Service.Contracts.Interfaces
{
    public interface IProductPresentationService
    {
        /// <summary>
        /// Получить список всех <see cref="ProductPresentationModel"/>
        /// </summary>
        Task<IEnumerable<ProductPresentationModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ProductPresentationModel"/> по идентификатору
        /// </summary>
        Task<ProductPresentationModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового <see cref="ProductPresentationModel"/>
        /// </summary>
        Task<ProductPresentationModel> AddAsync(ProductPresentationRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующую <see cref="ProductPresentationModel"/>
        /// </summary>
        Task<ProductPresentationModel> EditAsync(ProductPresentationRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего <see cref="ProductPresentationModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
