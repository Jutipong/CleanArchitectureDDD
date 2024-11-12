using System.Reflection;
using Domain.Abstractions;
using Infrastructure.Abstractions.Dapper;
using Infrastructure.Abstractions.EfCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnection = configuration.GetConnectionString("SqlServer") ?? throw new ArgumentNullException(nameof(configuration));

        AddPersistenceEfCore(services, sqlConnection);
        AddPersistenceDapper(services, sqlConnection);
        //AddRepositories(services);

        return services;
    }

    private static void AddPersistenceEfCore(IServiceCollection services, string sqlConnection)
    {
        services.AddDbContext<SqlContext>(options => options.UseSqlServer(sqlConnection, option => option.UseCompatibilityLevel(120)));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddPersistenceDapper(IServiceCollection services, string sqlConnection)
    {
        services.AddSingleton<IDapperConnection>(_ => new DapperConnection(sqlConnection));
    }

    //private static void AddRepositories(IServiceCollection services)
    //{
    //    var assembly = Assembly.GetExecutingAssembly();

    //    Console.WriteLine("Auto DI Repositories");

    //    var serviceTypes = assembly.GetTypes().Where(type => type.Name.EndsWith("Repository")).ToList();

    //    foreach (var serviceType in serviceTypes)
    //    {
    //        var interfaceType = serviceType.GetInterfaces().FirstOrDefault(type => type.Name.EndsWith(serviceType.Name));

    //        if (interfaceType != null)
    //        {
    //            services.AddScoped(interfaceType, serviceType);
    //            Console.WriteLine(interfaceType.Name + " -> " + serviceType.Name);
    //        }
    //    }

    //    Console.WriteLine("Auto DI Repositories Done");
    //}

    private static void AddRepository(this IServiceCollection services, Assembly assembly)
    {
        Console.WriteLine("Auto DI Repositories");

        var serviceTypes = assembly
            .GetTypes()
            .Where(type => type.Name.EndsWith("Repository") && type.GetInterfaces().Any(i => i.Name.EndsWith(type.Name)))
            .ToList();

        foreach (var serviceType in serviceTypes)
        {
            var interfaceType = serviceType.GetInterfaces().First(type => type.Name.EndsWith(serviceType.Name));
            services.AddSingleton(interfaceType, serviceType);
        }

        Console.WriteLine("Auto DI Repositories Done");
    }
}
