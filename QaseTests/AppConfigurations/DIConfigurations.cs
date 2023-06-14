using Microsoft.Extensions.DependencyInjection;
using QaseCore.BrowserFactory;

namespace QaseTests.AppConfigurations;

public static class DiConfigurations
{
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IBrowserService, BrowserService>(
            _ => new BrowserService(AppProperties.ChromeOptions, AppProperties.BrowserName)
            );
        return services;
    }
}