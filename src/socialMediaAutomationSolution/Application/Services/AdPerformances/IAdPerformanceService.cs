using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdPerformances;

public interface IAdPerformanceService
{
    Task<AdPerformance?> GetAsync(
        Expression<Func<AdPerformance, bool>> predicate,
        Func<IQueryable<AdPerformance>, IIncludableQueryable<AdPerformance, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AdPerformance>?> GetListAsync(
        Expression<Func<AdPerformance, bool>>? predicate = null,
        Func<IQueryable<AdPerformance>, IOrderedQueryable<AdPerformance>>? orderBy = null,
        Func<IQueryable<AdPerformance>, IIncludableQueryable<AdPerformance, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AdPerformance> AddAsync(AdPerformance adPerformance);
    Task<AdPerformance> UpdateAsync(AdPerformance adPerformance);
    Task<AdPerformance> DeleteAsync(AdPerformance adPerformance, bool permanent = false);
}
