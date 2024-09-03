using Domain.Consts;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Api.Minimal.Extensions;

public static class Cors
{
    public static void AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        var corsOrigins = configuration.GetSection("AppSettings")["CorsOrigins"] ?? "*";
        corsOrigins = string.IsNullOrWhiteSpace(corsOrigins) ? "*" : corsOrigins;

        services.AddCors(option =>
        {
            option.AddPolicy(
                name: APP.CORSPOLICY,
                builder =>
                {
                    builder.WithOrigins(corsOrigins).AllowAnyHeader().AllowAnyMethod();
                }
            );
        });
    }
}

internal static partial class ApplicationBuilder
{
    public static void UseCorsPolicy(this IApplicationBuilder app)
    {
        app.UseCors(APP.CORSPOLICY);
    }
}
