using ConversionSystem.Common.Entity.EntityInterfaces;

namespace ConversionSystem.Context.Contracts.Models
{
    /// <summary>
    /// Базовый класс с аудитом
    /// </summary>
    public abstract class BaseAuditEntity : IEntity,
        IEntityAuditCreated,
        IEntityAuditDeleted,
        IEntityAuditUpdated,
        IEntityWithId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}