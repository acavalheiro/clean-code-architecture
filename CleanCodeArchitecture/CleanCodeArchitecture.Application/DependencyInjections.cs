using CleanCodeArchitecture.Application.Core.PipelineBehavior;
using CleanCodeArchitecture.Domain.Core.PipelineBehavior;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCodeArchitecture.Application;

public class DependencyInjections
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CleanCodeArchitecture.Application.DependencyInjections).Assembly));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}