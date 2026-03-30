namespace ConversionSystem.Service.Contracts.Exceptions
{
    /// <summary>
    /// Ошибка выполнения операции
    /// </summary>
    public class ConversionInvalidOperationException : ConversionException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ConversionInvalidOperationException"/>
        /// с указанием сообщения об ошибке
        /// </summary>
        public ConversionInvalidOperationException(string message)
            : base(message) { }
    }
}
