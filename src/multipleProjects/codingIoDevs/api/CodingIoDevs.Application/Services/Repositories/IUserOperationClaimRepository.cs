using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace CodingIoDevs.Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
{
}