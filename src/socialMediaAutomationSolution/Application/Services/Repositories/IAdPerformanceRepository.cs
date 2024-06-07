using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdPerformanceRepository : IAsyncRepository<AdPerformance, Guid>, IRepository<AdPerformance, Guid>
{
}