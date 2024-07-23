using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

namespace Api.Controller.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, bool isControllerApi = false)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Description = "Minimal API Demo",
                    Title = "Minimal API Demo",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "[Name]"
                        // Url = new Uri("")
                    }
                }
            );
            c.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n "
                        + "Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\n"
                        + "Example: Bearer token"
                }
            );
            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                }
            );

            if (isControllerApi)
            {
                // For use Controller
                c.TagActionsBy(api =>
                {
                    return api.GroupName != null
                        ? ([api.GroupName])
                        : api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor
                            ? (IList<string>)([controllerActionDescriptor.ControllerName])
                            : throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                c.DocInclusionPredicate((name, api) => true);
            }
        });

        return services;
    }
}

internal static partial class ApplicationBuilder
{
    public static IApplicationBuilder UseSwaggerEndpoints(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            //c.RoutePrefix = string.Empty;
        });

        return app;
    }
}
