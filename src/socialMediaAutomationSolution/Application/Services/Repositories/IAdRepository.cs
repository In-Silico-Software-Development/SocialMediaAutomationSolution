using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdRepository : IAsyncRepository<Ad, Guid>, IRepository<Ad, Guid>
{
}