using CleanCodeArchitecture.Application.Core.PipelineBehavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCodeArchitecture.Application;

public static class DependencyInjections
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CleanCodeArchitecture.Application.DependencyInjections).Assembly));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(typeof(CleanCodeArchitecture.Application.DependencyInjections).Assembly);
        
        return services;
    }
}