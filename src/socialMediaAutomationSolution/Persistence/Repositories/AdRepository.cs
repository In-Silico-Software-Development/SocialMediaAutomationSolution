using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdRepository : EfRepositoryBase<Ad, Guid, BaseDbContext>, IAdRepository
{
    public AdRepository(BaseDbContext context) : base(context)
    {
    }
}