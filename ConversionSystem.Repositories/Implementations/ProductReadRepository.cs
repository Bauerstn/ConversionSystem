using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Common.Entity.Repositories;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConversionSystem.Repositories.Implementations
{
    public class ProductReadRepository : IProductReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public ProductReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Product>> IProductReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Product>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Product?> IProductReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Product>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Product>> IProductReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Product>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IProductReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Product>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);
    }
}
