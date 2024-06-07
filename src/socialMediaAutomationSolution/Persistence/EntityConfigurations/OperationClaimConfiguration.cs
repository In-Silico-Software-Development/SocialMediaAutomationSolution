using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Ads.Constants;
using Application.Features.AdPerformances.Constants;
using Application.Features.Notifications.Constants;
using Application.Features.SocialMediaAccounts.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Ads CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdsOperationClaims.Read },
                new() { Id = ++lastId, Name = AdsOperationClaims.Write },
                new() { Id = ++lastId, Name = AdsOperationClaims.Create },
                new() { Id = ++lastId, Name = AdsOperationClaims.Update },
                new() { Id = ++lastId, Name = AdsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region AdPerformances CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Read },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Write },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Create },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Update },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SocialMediaAccounts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Read },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Write },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Create },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Update },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Ads CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdsOperationClaims.Read },
                new() { Id = ++lastId, Name = AdsOperationClaims.Write },
                new() { Id = ++lastId, Name = AdsOperationClaims.Create },
                new() { Id = ++lastId, Name = AdsOperationClaims.Update },
                new() { Id = ++lastId, Name = AdsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region AdPerformances CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Read },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Write },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Create },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Update },
                new() { Id = ++lastId, Name = AdPerformancesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SocialMediaAccounts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Read },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Write },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Create },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Update },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
