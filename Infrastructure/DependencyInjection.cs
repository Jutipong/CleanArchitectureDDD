using Domain.Interfaces;
using Infrastructure.Databases.SqlServer;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);

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

        // Register repositories
        //var assembly = Assembly.GetExecutingAssembly();
        //var serviceTypes = assembly
        //    .GetTypes()
        //    .Where(type => type.Name.EndsWith("Repository"))
        //    .ToList();

        //foreach(var serviceType in serviceTypes)
        //{
        //    var interfaceType = serviceType
        //        .GetInterfaces()
        //        .FirstOrDefault(type => type.Name.EndsWith(serviceType.Name));

        //    if(interfaceType != null)
        //    {
        //        services.AddScoped(interfaceType, serviceType);
        //    }
        //}

        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}