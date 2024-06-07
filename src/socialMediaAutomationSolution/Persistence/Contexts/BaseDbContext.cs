using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NArchitecture.Core.Security.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Ad> Ads { get; set; }
    public DbSet<AdPerformance> AdPerformances { get; set; }
    public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Campaign>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserGuid)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Ad>()
            .HasOne(a => a.Campaign)
            .WithMany(c => c.Ads)
            .HasForeignKey(a => a.CampaignGuid)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Ad>()
            .HasMany(a => a.Performances)
            .WithOne(p => p.Ad)
            .HasForeignKey(p => p.AdGuid)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SocialMediaAccount>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany()
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Additional configurations
        modelBuilder.Entity<Campaign>()
            .Property(c => c.Budget)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<AdPerformance>()
            .Property(p => p.Cost)
            .HasColumnType("decimal(18,2)");

        // Indexes
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Ad>()
            .HasIndex(a => a.ScheduledTime);

        modelBuilder.Entity<AdPerformance>()
            .HasIndex(p => p.Date);
    }
}
