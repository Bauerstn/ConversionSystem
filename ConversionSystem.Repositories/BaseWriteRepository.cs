using ConversionSystem.Common.Entity.EntityInterfaces;
using ConversionSystem.Common.Entity.InterfacesDB;
using ConversionSystem.Repositories.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace ConversionSystem.Repositories
{
    /// <summary>
    /// Базовый класс репозитория записи данных
    /// </summary>
    public abstract class BaseWriteRepository<T> : IRepositoryWriter<T> where T : class, IEntity
    {
        /// <inheritdoc cref="IDbWriterContext"/>
        private readonly IDbWriterContext writerContext;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="BaseWriteRepository{T}"/>
        /// </summary>
        protected BaseWriteRepository(IDbWriterContext writerContext)
        {
            this.writerContext = writerContext;
        }

        /// <inheritdoc cref="IRepositoryWriter{T}"/>
        public virtual void Add([NotNull] T entity)
        {
            if (entity is IEntityWithId entityWithId && entityWithId.Id == Guid.Empty)
            {
                entityWithId.Id = Guid.NewGuid();
            }
            AuditForCreate(entity);
            AuditForUpdate(entity);
            writerContext.Writer.Add(entity);
        }

        /// <inheritdoc cref="IRepositoryWriter{T}"/>
        public void Update([NotNull] T entity)
        {
            AuditForUpdate(entity);
            writerContext.Writer.Update(entity);
        }

        /// <inheritdoc cref="IRepositoryWriter{T}"/>
        public void Delete([NotNull] T entity)
        {
            AuditForUpdate(entity);
            AuditForDelete(entity);
            if (entity is IEntityAuditDeleted)
            {
                writerContext.Writer.Update(entity);
            }
            else
            {
                writerContext.Writer.Delete(entity);
            }
        }

        private void AuditForCreate([NotNull] T entity)
        {
            if (entity is IEntityAuditCreated auditCreated)
            {
                auditCreated.CreatedAt = writerContext.DateTimeProvider.UtcNow;
            }
        }

        public void AuditForUpdate([NotNull] T entity)
        {
            if (entity is IEntityAuditUpdated auditUpdate)
            {
                auditUpdate.UpdatedAt = writerContext.DateTimeProvider.UtcNow;
            }
        }

        private void AuditForDelete([NotNull] T entity)
        {
            if (entity is IEntityAuditDeleted auditDeleted)
            {
                auditDeleted.DeletedAt = writerContext.DateTimeProvider.UtcNow;
            }
        }
    }
}
