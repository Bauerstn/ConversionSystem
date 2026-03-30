using ConversionSystem.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversionSystem.Context.Configuration.TypeConfigurations
{
    public class ProductPresentationEntityTypeConfiguration : IEntityTypeConfiguration<ProductPresentation>
    {
        public void Configure(EntityTypeBuilder<ProductPresentation> builder)
        {
            builder.ToTable("ProductPresentations");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.PresentationType)
                .IsRequired();

            builder.Property(x => x.ViewCount)
                .IsRequired();

            builder.HasIndex(x => x.PresentationType)
                .HasFilter($"{nameof(ProductPresentation.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(ProductPresentation)}_{nameof(ProductPresentation.PresentationType)}");

            builder.HasMany(x => x.ReportResult)
                .WithOne(x => x.ProductPresentation)
                .HasForeignKey(x => x.ProductPresentationId);
        }
    }
}
