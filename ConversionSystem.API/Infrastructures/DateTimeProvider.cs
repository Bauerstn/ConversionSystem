using ConversionSystem.Common;

namespace ConversionSystem.API.Infrastructures
{
    /// <inheritdoc cref="IDateTimeProvider"/>
    public class DateTimeProvider : IDateTimeProvider
    {
        DateTimeOffset IDateTimeProvider.UtcNow => DateTimeOffset.UtcNow;
    }
}
