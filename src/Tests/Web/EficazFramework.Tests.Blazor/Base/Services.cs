using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Bunit;

namespace EficazFramework.Tests.Extensions;


public static class TestContextExtensions
{
    public static void AddTestServices(this TestContext ctx)
    {
        ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        ctx.Services.AddSingleton<NavigationManager>(new EficazFramework.Tests.Blazor.Views.Resources.Mocks.NavigationManager());
        ctx.Services.AddMudServices(options =>
        {
            options.SnackbarConfiguration.ShowTransitionDuration = 0;
            options.SnackbarConfiguration.HideTransitionDuration = 0;
        });
        ctx.Services.AddScoped(sp => new HttpClient());
        ctx.Services.AddOptions();
    }
}
