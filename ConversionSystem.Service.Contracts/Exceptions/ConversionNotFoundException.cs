namespace ConversionSystem.Service.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемый ресурс не найден
    /// </summary>
    public class ConversionNotFoundException : ConversionException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ConversionNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public ConversionNotFoundException(string message)
            : base(message) { }
    }
}
