using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace CodingIoDevs.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
    IList<OperationClaim> GetClaims(User user);
}