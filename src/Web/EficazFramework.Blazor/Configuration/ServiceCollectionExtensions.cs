using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace EficazFramework.Configuration;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddEficazFramework(this IServiceCollection serviceCollection, bool applicationManager = false)
    {
        serviceCollection.AddThemeProvider()
                         .AddMudServices();

        if (applicationManager)
            serviceCollection.AddApplicationManager();

        return serviceCollection;
    }

    private static IServiceCollection AddApplicationManager(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Application.IApplicationManager>(builder => EficazFramework.Application.IApplicationManager.Create());
    }

    private static IServiceCollection AddThemeProvider(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Services.IThemeProvider, EficazFramework.Services.ThemeProvider>();
    }

}
