using Core.Persistence.Repositories;
using Core.Security.Entities;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Persistence.Contexts;

namespace CodingIoDevs.Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context) : base(context)
    {
    }
}