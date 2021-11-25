using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace EficazFramework.Configuration;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddEficazFramework(this IServiceCollection serviceCollection, bool applicationManager = false, bool sessionManager = false)
    {
        if (applicationManager)
            serviceCollection.AddApplicationManager();

        if (sessionManager)
            serviceCollection.AddSessionManager();

        return serviceCollection.AddThemeProvider()
                                .AddMudServices()
                                .AddMudBlazorScrollManager();
    }

    private static IServiceCollection AddApplicationManager(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Application.ScopedApplicationManager>();
    }

    private static IServiceCollection AddSessionManager(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Application.ScopedSessionManager>();
    }

    private static IServiceCollection AddThemeProvider(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<EficazFramework.Services.ThemeProvider>();
    }

}
