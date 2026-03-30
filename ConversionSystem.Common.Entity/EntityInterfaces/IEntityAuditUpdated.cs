namespace ConversionSystem.Common.Entity.EntityInterfaces
{
    /// <summary>
    /// Аудит создания сущности
    /// </summary>
    public interface IEntityAuditUpdated
    {
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset UpdatedAt {  get; set; }
    }
}
