using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

namespace Api.Controller.Extensions;

public static class SerializeOption
{
    public static void AddJsonOptions(this IServiceCollection services)
    {
        services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.PropertyNamingPolicy = null;
        });
    }
}
