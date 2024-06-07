using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdPerformanceConfiguration : IEntityTypeConfiguration<AdPerformance>
{
    public void Configure(EntityTypeBuilder<AdPerformance> builder)
    {
        builder.ToTable("AdPerformances").HasKey(ap => ap.Id);

        builder.Property(ap => ap.Id).HasColumnName("Id").IsRequired();
        builder.Property(ap => ap.AdGuid).HasColumnName("AdGuid").IsRequired();
        builder.Property(ap => ap.Ad).HasColumnName("Ad").IsRequired();
        builder.Property(ap => ap.Impressions).HasColumnName("Impressions").IsRequired();
        builder.Property(ap => ap.Clicks).HasColumnName("Clicks").IsRequired();
        builder.Property(ap => ap.Conversions).HasColumnName("Conversions").IsRequired();
        builder.Property(ap => ap.Cost).HasColumnName("Cost").IsRequired();
        builder.Property(ap => ap.Date).HasColumnName("Date").IsRequired();
        builder.Property(ap => ap.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ap => ap.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ap => ap.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ap => !ap.DeletedDate.HasValue);
    }
}