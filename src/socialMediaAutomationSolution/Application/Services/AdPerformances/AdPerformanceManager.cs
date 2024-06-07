using Application.Features.AdPerformances.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdPerformances;

public class AdPerformanceManager : IAdPerformanceService
{
    private readonly IAdPerformanceRepository _adPerformanceRepository;
    private readonly AdPerformanceBusinessRules _adPerformanceBusinessRules;

    public AdPerformanceManager(IAdPerformanceRepository adPerformanceRepository, AdPerformanceBusinessRules adPerformanceBusinessRules)
    {
        _adPerformanceRepository = adPerformanceRepository;
        _adPerformanceBusinessRules = adPerformanceBusinessRules;
    }

    public async Task<AdPerformance?> GetAsync(
        Expression<Func<AdPerformance, bool>> predicate,
        Func<IQueryable<AdPerformance>, IIncludableQueryable<AdPerformance, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AdPerformance? adPerformance = await _adPerformanceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return adPerformance;
    }

    public async Task<IPaginate<AdPerformance>?> GetListAsync(
        Expression<Func<AdPerformance, bool>>? predicate = null,
        Func<IQueryable<AdPerformance>, IOrderedQueryable<AdPerformance>>? orderBy = null,
        Func<IQueryable<AdPerformance>, IIncludableQueryable<AdPerformance, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AdPerformance> adPerformanceList = await _adPerformanceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return adPerformanceList;
    }

    public async Task<AdPerformance> AddAsync(AdPerformance adPerformance)
    {
        AdPerformance addedAdPerformance = await _adPerformanceRepository.AddAsync(adPerformance);

        return addedAdPerformance;
    }

    public async Task<AdPerformance> UpdateAsync(AdPerformance adPerformance)
    {
        AdPerformance updatedAdPerformance = await _adPerformanceRepository.UpdateAsync(adPerformance);

        return updatedAdPerformance;
    }

    public async Task<AdPerformance> DeleteAsync(AdPerformance adPerformance, bool permanent = false)
    {
        AdPerformance deletedAdPerformance = await _adPerformanceRepository.DeleteAsync(adPerformance);

        return deletedAdPerformance;
    }
}
