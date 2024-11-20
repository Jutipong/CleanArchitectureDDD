namespace Api.Controller.Extensions;

public static class JsonOptionExtension
{
    public static void AddJsonOptions(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
    }
}
