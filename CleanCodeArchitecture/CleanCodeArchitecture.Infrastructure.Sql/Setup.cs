using CleanCodeArchitecture.Domain.Core.Repositories;
using CleanCodeArchitecture.Domain.Repositories;
using CleanCodeArchitecture.Infrastructure.Sql.Data;
using CleanCodeArchitecture.Infrastructure.Sql.Repositories;
using CleanCodeArchitecture.Infrastructure.Sql.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCodeArchitecture.Infrastructure.Sql;

public static class Setup
{
    public static IServiceCollection AddApplicationContext(this IServiceCollection services, string connectionString)
    {
        

        services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddApplicationContextInMemory(this IServiceCollection services)
    {


        services.AddDbContext<ApplicationContext>(options =>
            options.UseInMemoryDatabase("TestDatabase"));

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddTransient<ICompanyRepository, CompanyRepository>();

        return services;
    }
}