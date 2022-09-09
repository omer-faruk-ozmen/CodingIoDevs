using CodingIoDevs.Domain.Entities;
using Core.Persistence.Repositories;

namespace CodingIoDevs.Application.Services.Repositories;

public interface IUserLinkRepository : IAsyncRepository<UserLink>, IRepository<UserLink>
{
}