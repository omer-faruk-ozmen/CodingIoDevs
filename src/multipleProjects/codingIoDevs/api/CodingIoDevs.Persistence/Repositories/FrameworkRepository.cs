using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using CodingIoDevs.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace CodingIoDevs.Persistence.Repositories;

public class FrameworkRepository : EfRepositoryBase<Framework, BaseDbContext>, IFrameworkRepository
{
    public FrameworkRepository(BaseDbContext context) : base(context)
    {
    }
}