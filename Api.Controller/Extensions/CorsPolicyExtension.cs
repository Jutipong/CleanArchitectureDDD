using Domain.Consts;

namespace Api.Controller.Extensions;

public static class CorsExtension
{
    public static WebApplicationBuilder AddCorsPolicy(this WebApplicationBuilder builder)
    {
        var allowedHosts = builder.Configuration.GetSection("AllowedHosts").Value;
        var corsOrigins = allowedHosts ?? "*";

        builder.Services.AddCors(option =>
        {
            option.AddPolicy(
                APP.CORSPOLICY,
                bd =>
                {
                    bd.WithOrigins(corsOrigins).AllowAnyHeader().AllowAnyMethod();
                }
            );
        });

        return builder;
    }
}

internal static partial class ApplicationBuilder
{
    public static void UseCorsPolicy(this IApplicationBuilder app)
    {
        app.UseCors(APP.CORSPOLICY);
    }
}
