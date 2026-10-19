using Microsoft.Extensions.Configuration;

namespace Bai1.Configuration;

public static class ConfigurationHelper
{
    private static AppConfig? _appConfig;
    private static IConfiguration? _configuration;

    public static AppConfig Config
    {
        get
        {
            if (_appConfig == null)
            {
                LoadConfiguration();
            }
            return _appConfig!;
        }
    }

    public static void LoadConfiguration()
    {
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

        _configuration = builder.Build();

        _appConfig = new AppConfig();
        _configuration.Bind(_appConfig);
    }

    public static string GetConnectionString()
    {
        return Config.ConnectionStrings.DefaultConnection;
    }
}
