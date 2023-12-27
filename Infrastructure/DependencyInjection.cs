using Domain.Abstractions;
using Infrastructure.Databases;
using Infrastructure.Databases.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);
        AddRepositories(services);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnection =
            configuration.GetConnectionString("SqlServer") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<SqlContext>(
            options => options.UseSqlServer(sqlConnection,
            option => option.UseCompatibilityLevel(120)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var serviceTypes = assembly.GetTypes()
                                   .Where(type => type.Name.EndsWith("Repository"))
                                   .ToList();

        foreach(var serviceType in serviceTypes)
        {
            var interfaceType = serviceType.GetInterfaces()
                                           .FirstOrDefault(type => type.Name.EndsWith(serviceType.Name));

            if(interfaceType != null)
            {
                services.AddScoped(interfaceType, serviceType);
            }
        }
    }
}