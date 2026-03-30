using ConversionSystem.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversionSystem.Context.Configuration.TypeConfigurations
{
    public class ReportResultEntityTypeConfiguration : IEntityTypeConfiguration<ReportResult>
    {
        public void Configure(EntityTypeBuilder<ReportResult> builder)
        {
            builder.ToTable("ReportResults");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.ViewToPaymentRatio)
                .IsRequired();

            builder.HasIndex(x => x.Id)
                .HasDatabaseName($"IX_{nameof(ReportResult)}_{nameof(ReportResult.Id)}");
        }
    }
}
