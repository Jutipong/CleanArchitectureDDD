namespace Api.Minimal.Extensions;

public static class SerializeOption
{
    public static void AddJsonOptions(this IServiceCollection services)
    {
        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.PropertyNamingPolicy = null;
        });
    }
}
