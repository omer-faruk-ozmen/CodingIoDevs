using CodingIoDevs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodingIoDevs.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
{
    public BaseDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<BaseDbContext> dbContextOptionsBuilder = new();

        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
        return new (dbContextOptionsBuilder.Options);
    }
}