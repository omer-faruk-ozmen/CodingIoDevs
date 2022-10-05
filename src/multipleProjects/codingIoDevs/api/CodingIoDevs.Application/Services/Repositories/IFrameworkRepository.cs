using CodingIoDevs.Domain.Entities;
using Core.Persistence.Repositories;

namespace CodingIoDevs.Application.Services.Repositories;

public interface IFrameworkRepository : IAsyncRepository<Framework>, IRepository<Framework>
{
}