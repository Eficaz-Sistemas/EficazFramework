using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEficazFramework(this IServiceCollection serviceCollection, Action<Configuration.ServiceConfiguration>? options = null)
    {
        if (serviceCollection == null)
            throw new ArgumentNullException(nameof(serviceCollection));

        Configuration.ServiceConfiguration config = new();

        if (options != null)
        {
            serviceCollection.Configure(options);
            options.Invoke(config);
        }

        serviceCollection.AddThemeProvider(config.Theme)
                         .AddMudServices(config.MudBlazorConfigurations);

        if (config.UseApplicationManager)
            serviceCollection.AddApplicationManager();

        return serviceCollection;
    }

    private static IServiceCollection AddApplicationManager(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Application.IApplicationManager>(builder => Application.IApplicationManager.Create());
    }

    private static IServiceCollection AddThemeProvider(this IServiceCollection serviceCollection, MudBlazor.MudTheme theme)
    {
        return serviceCollection.AddScoped<IThemeProvider>(x => new ThemeProvider(theme));
    }


}
