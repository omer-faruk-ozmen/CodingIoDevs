using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using CodingIoDevs.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace CodingIoDevs.Persistence.Repositories;

public class UserLinkRepository : EfRepositoryBase<UserLink, BaseDbContext>, IUserLinkRepository
{
    public UserLinkRepository(BaseDbContext context) : base(context)
    {
    }
}