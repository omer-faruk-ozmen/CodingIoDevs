using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Persistence.Contexts;
using CodingIoDevs.Persistence.Repositories;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodingIoDevs.Persistence.Extensions;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));

        var seedData = new SeedData();
        seedData.SeedAsync().GetAwaiter().GetResult();

        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        services.AddScoped<IFrameworkRepository, FrameworkRepository>();
        services.AddScoped<IUserLinkRepository, UserLinkRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        

        return services;

    }
}