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

        //services.AddDbContext<SqlContext>(
        //    options => options.UseSqlServer(sqlConnection,
        //    option => option.UseCompatibilityLevel(120)));

        //services.AddDbContext<TDRDbContext>(
        //    options => options.UseSqlServer(sqlConnection,
        //    option => option.UseCompatibilityLevel(120)));


        //services.AddScoped<IUnitOfWork, TDRUnitOfWork>();
    }
}