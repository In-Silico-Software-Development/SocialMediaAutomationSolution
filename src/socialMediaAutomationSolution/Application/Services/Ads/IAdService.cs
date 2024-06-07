using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ads;

public interface IAdService
{
    Task<Ad?> GetAsync(
        Expression<Func<Ad, bool>> predicate,
        Func<IQueryable<Ad>, IIncludableQueryable<Ad, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ad>?> GetListAsync(
        Expression<Func<Ad, bool>>? predicate = null,
        Func<IQueryable<Ad>, IOrderedQueryable<Ad>>? orderBy = null,
        Func<IQueryable<Ad>, IIncludableQueryable<Ad, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ad> AddAsync(Ad ad);
    Task<Ad> UpdateAsync(Ad ad);
    Task<Ad> DeleteAsync(Ad ad, bool permanent = false);
}
