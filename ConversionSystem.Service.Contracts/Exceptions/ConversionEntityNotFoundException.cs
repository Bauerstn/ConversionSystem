namespace ConversionSystem.Service.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемая сущность не найдена
    /// </summary>
    public class ConversionEntityNotFoundException<TEntity> : ConversionNotFoundException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ConversionEntityNotFoundException{TEntity}"/>
        /// </summary>
        public ConversionEntityNotFoundException(Guid id)
            : base($"Сущность {typeof(TEntity)} c id = {id} не найдена.")
        { }
    }
}
