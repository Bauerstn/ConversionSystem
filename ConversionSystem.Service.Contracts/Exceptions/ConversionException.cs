namespace ConversionSystem.Service.Contracts.Exceptions
{
    /// <summary>
    /// Базовый класс исключений
    /// </summary>
    public abstract class ConversionException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ConversionException"/> без параметров
        /// </summary>
        protected ConversionException() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ConversionException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        protected ConversionException(string message)
            : base(message) { }
    }
}
