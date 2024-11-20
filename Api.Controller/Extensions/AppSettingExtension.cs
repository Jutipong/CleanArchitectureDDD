using Domain.Abstractions;

namespace Api.Controller.Extensions;

public static class AppSettingExtension
{
    public static AppSettings AddAppSetting(this WebApplicationBuilder builder)
    {
        var appSetting =
            builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>()
            ?? throw new ArgumentNullException(nameof(AppSettings));

        builder.Services.AddSingleton(appSetting);

        return appSetting;
    }
}
