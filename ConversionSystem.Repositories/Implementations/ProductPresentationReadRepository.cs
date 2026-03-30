using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Common.Entity.Repositories;
using ConversionSystem.Context.Contracts.Enums;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConversionSystem.Repositories.Implementations
{
    public class ProductPresentationReadRepository : IProductPresentationReadRepository, IRepositoryAnchor
    {
        private IDbReader reader;

        public ProductPresentationReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<ProductPresentation>> IProductPresentationReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<ProductPresentation>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<ProductPresentation?> IProductPresentationReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<ProductPresentation>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, ProductPresentation>> IProductPresentationReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<ProductPresentation>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<ProductPresentation?> IProductPresentationReadRepository.GetByProductIdAndPresentationTypeAsync(Guid productId, PresentationTypes presentationType, CancellationToken cancellationToken)
            => reader.Read<ProductPresentation>()
                .NotDeletedAt()
                .Where(x => x.ProductId == productId && x.PresentationType == presentationType)
                .FirstOrDefaultAsync(cancellationToken);

        Task<bool> IProductPresentationReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Product>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);
    }
}
