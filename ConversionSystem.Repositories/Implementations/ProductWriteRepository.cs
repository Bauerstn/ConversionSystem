using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;

namespace ConversionSystem.Repositories.Implementations
{
    public class ProductWriteRepository : BaseWriteRepository<Product>,
        IProductWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ProductWriteRepository"/>
        /// </summary>
        public ProductWriteRepository(IDbWriterContext writerContext)
            : base(writerContext) { }
    }
}
