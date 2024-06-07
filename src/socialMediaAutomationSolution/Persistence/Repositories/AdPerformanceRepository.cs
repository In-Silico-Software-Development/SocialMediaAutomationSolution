using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdPerformanceRepository : EfRepositoryBase<AdPerformance, Guid, BaseDbContext>, IAdPerformanceRepository
{
    public AdPerformanceRepository(BaseDbContext context) : base(context)
    {
    }
}