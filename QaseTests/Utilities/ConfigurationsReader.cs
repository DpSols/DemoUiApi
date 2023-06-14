using Microsoft.Extensions.Configuration;
using QaseCore.Utilities;

namespace QaseTests.Utilities;

public static class ConfigurationsReader
{
    public static IConfiguration Configuration { get; }

    static ConfigurationsReader()
    {
        var pathToAppsettings = Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json");
        Logger.Instance.Debug($"Getting configurations from {pathToAppsettings}.");
        Configuration = new ConfigurationBuilder()
            .AddJsonFile(pathToAppsettings)
            .Build();
    }
}