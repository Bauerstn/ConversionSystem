namespace ConversionSystem.Common.Entity.EntityInterfaces
{
    /// <summary>
    /// Аудит создания сущности
    /// </summary>
    public interface IEntityAuditCreated
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreatedAt {  get; set; }
    }
}
