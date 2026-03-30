namespace ConversionSystem.Common.Entity.InterfacesDB
{
    /// <summary>
    /// Определяет контекст репозитория записи сущностей
    /// </summary>
    public interface IDbWriterContext
    {
        /// <inheritdoc cref="IDbWriter"/>
        IDbWriter Writer { get; }


        /// <inheritdoc cref="IUnitOfWork"/>
        IUnitOfWork UnitOfWork { get; }


        /// <inheritdoc cref="IDateTimeProvider"/>
        IDateTimeProvider DateTimeProvider { get; }
    }
}
