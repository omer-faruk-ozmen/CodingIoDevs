using System.Reflection;
using CodingIoDevs.Application.Features.Auth.Rules;
using CodingIoDevs.Application.Features.Frameworks.Rules;
using CodingIoDevs.Application.Features.OperationClaims.Rules;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Rules;
using CodingIoDevs.Application.Features.UserLinks.Rules;
using CodingIoDevs.Application.Features.UserOperationClaims.Rules;
using CodingIoDevs.Application.Services.AuthService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        services.AddScoped<OperationClaimBusinessRules>();
        services.AddScoped<UserOperationClaimBusinessRules>();

        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));


        services.AddScoped<IAuthService, AuthManager>();

        return services;
    }
}