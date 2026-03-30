using ConversionSystem.Common.Entity.EntityInterfaces;
using ConversionSystem.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversionSystem.Context.Configuration
{
    /// <summary>
    /// Методы расширения для <see cref="EntityTypeBuilder"/>
    /// </summary>
    static internal class EnityTypeBuilderExtensions
    {
        /// <summary>
        /// Задаёт конфигурацию свойств аудита для сущности <inheritdoc cref="BaseAuditEntity"/>
        /// </summary>
        public static void PropertyAuditConfiguration<T>(this EntityTypeBuilder<T> builder)
            where T : BaseAuditEntity
        {
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
        }

        /// <summary>
        /// Задаёт конфигурацию ключа для идентификатора <see cref="IEntityWithId.Id"/>
        /// </summary>
        public static void HasIdAsKey<T>(this EntityTypeBuilder<T> builder)
            where T : class, IEntityWithId
            => builder.HasKey(x => x.Id);
    }
}
