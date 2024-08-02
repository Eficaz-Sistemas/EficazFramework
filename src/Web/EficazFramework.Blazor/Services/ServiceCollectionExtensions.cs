using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace EficazFramework.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEficazFramework(this IServiceCollection serviceCollection, Action<Configuration.ServiceConfiguration>? options = null)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);

        Configuration.ServiceConfiguration config = new();

        if (options != null)
        {
            serviceCollection.Configure(options);
            options.Invoke(config);
        }

        serviceCollection.AddThemeProvider(config.Theme, config.ThemeIsDarkMode)
                         .AddMudServices(config.MudBlazorConfigurations);

        if (config.UseApplicationManager)
            serviceCollection.AddApplicationManager();

        return serviceCollection;
    }

    private static IServiceCollection AddApplicationManager(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Application.IApplicationManager>(builder => Application.IApplicationManager.Instance);
    }

    private static IServiceCollection AddThemeProvider(this IServiceCollection serviceCollection, MudBlazor.MudTheme theme, bool darkMode)
    {
        return serviceCollection.AddScoped<IThemeProvider>(x => new ThemeProvider(theme) { IsDarkMode = darkMode });
    }


}
