using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdConfiguration : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> builder)
    {
        builder.ToTable("Ads").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Platform).HasColumnName("Platform").IsRequired();
        builder.Property(a => a.Content).HasColumnName("Content").IsRequired();
        builder.Property(a => a.ScheduledTime).HasColumnName("ScheduledTime").IsRequired();
        builder.Property(a => a.IsPublished).HasColumnName("IsPublished").IsRequired();
        builder.Property(a => a.CampaignGuid).HasColumnName("CampaignGuid").IsRequired();
        builder.Property(a => a.Campaign).HasColumnName("Campaign").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}