using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.Auth.Rules;
using CodingIoDevs.Application.Features.Frameworks.Rules;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Rules;
using CodingIoDevs.Application.Features.UserLinks.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CodingIoDevs.Application.Extensions;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<FrameworkBusinessRules>();
        services.AddScoped<UserLinkBusinessRules>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


        return services;
    }
}