using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;

namespace ConversionSystem.Repositories.Implementations
{
    public class ProductPresentationWriteRepository : BaseWriteRepository<ProductPresentation>,
        IProductPresentationWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ProductPresentationWriteRepository"/>
        /// </summary>
        public ProductPresentationWriteRepository(IDbWriterContext writerContext)
            : base(writerContext) { }
    }
}