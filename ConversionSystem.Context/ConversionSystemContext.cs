using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Context.Configuration;
using ConversionSystem.Context.Contracts;
using ConversionSystem.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace ConversionSystem.Context
{
    public class ConversionSystemContext : DbContext,
        IConversionSystemContext,
        IDbReader,
        IDbWriter,
        IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPresentation> ProductPresentations { get; set; }
        public DbSet<ReportResult> ReportResults { get; set; }

        public ConversionSystemContext(DbContextOptions<ConversionSystemContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IContextConfigurationAnchor).Assembly);
        }

        IQueryable<TEntity> IDbReader.Read<TEntity>()
            => base.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();

        void IDbWriter.Add<TEntities>(TEntities entity)
            => base.Entry(entity).State = EntityState.Added;

        void IDbWriter.Update<TEntities>(TEntities entity)
            => base.Entry(entity).State = EntityState.Modified;

        void IDbWriter.Delete<TEntities>(TEntities entity)
            => base.Entry(entity).State = EntityState.Deleted;

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }
            return count;
        }
    }
}
