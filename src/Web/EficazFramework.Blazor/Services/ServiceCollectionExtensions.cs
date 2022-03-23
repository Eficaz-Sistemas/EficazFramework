using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Services;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddEficazFramework(this IServiceCollection serviceCollection, Configuration.ServiceConfiguration? options = null)
    {
        serviceCollection.AddThemeProvider(options?.Theme)
                         .AddMudServices(options?.MudBlazorConfigurations);

        if (options?.UseApplicationManager ?? false)
            serviceCollection.AddApplicationManager();

        return serviceCollection;
    }

    private static IServiceCollection AddApplicationManager(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Application.IApplicationManager>(builder => EficazFramework.Application.IApplicationManager.Create());
    }

    private static IServiceCollection AddThemeProvider(this IServiceCollection serviceCollection, MudBlazor.MudTheme? theme)
    {
        return serviceCollection.AddScoped<EficazFramework.Services.IThemeProvider>(x => new EficazFramework.Services.ThemeProvider(theme));
    }

}
