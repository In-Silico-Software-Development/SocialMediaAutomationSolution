using Application.Features.Ads.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ads;

public class AdManager : IAdService
{
    private readonly IAdRepository _adRepository;
    private readonly AdBusinessRules _adBusinessRules;

    public AdManager(IAdRepository adRepository, AdBusinessRules adBusinessRules)
    {
        _adRepository = adRepository;
        _adBusinessRules = adBusinessRules;
    }

    public async Task<Ad?> GetAsync(
        Expression<Func<Ad, bool>> predicate,
        Func<IQueryable<Ad>, IIncludableQueryable<Ad, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ad? ad = await _adRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ad;
    }

    public async Task<IPaginate<Ad>?> GetListAsync(
        Expression<Func<Ad, bool>>? predicate = null,
        Func<IQueryable<Ad>, IOrderedQueryable<Ad>>? orderBy = null,
        Func<IQueryable<Ad>, IIncludableQueryable<Ad, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ad> adList = await _adRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return adList;
    }

    public async Task<Ad> AddAsync(Ad ad)
    {
        Ad addedAd = await _adRepository.AddAsync(ad);

        return addedAd;
    }

    public async Task<Ad> UpdateAsync(Ad ad)
    {
        Ad updatedAd = await _adRepository.UpdateAsync(ad);

        return updatedAd;
    }

    public async Task<Ad> DeleteAsync(Ad ad, bool permanent = false)
    {
        Ad deletedAd = await _adRepository.DeleteAsync(ad);

        return deletedAd;
    }
}
