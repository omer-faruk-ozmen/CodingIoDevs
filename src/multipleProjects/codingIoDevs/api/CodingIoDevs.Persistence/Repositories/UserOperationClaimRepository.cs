using Core.Persistence.Repositories;
using Core.Security.Entities;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Persistence.Contexts;

namespace CodingIoDevs.Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}