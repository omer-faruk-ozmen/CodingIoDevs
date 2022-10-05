using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Persistence.Contexts;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace CodingIoDevs.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}