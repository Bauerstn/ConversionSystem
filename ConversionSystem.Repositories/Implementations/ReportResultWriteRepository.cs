using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Repositories.Contracts.Interfaces;

namespace ConversionSystem.Repositories.Implementations
{
    public class ReportResultWriteRepository : BaseWriteRepository<ReportResult>,
        IReportResultWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ReportResultWriteRepository"/>
        /// </summary>
        public ReportResultWriteRepository(IDbWriterContext writerContext)
            : base(writerContext) { }
    }
}
