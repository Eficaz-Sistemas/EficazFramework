using Bunit;
using EficazFramework.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Net.Http;

namespace EficazFramework.Tests.Extensions;


public static class TestContextExtensions
{
    public static void AddTestServices(this TestContext ctx)
    {
        ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        ctx.Services.AddSingleton<NavigationManager>(new EficazFramework.Tests.Blazor.Views.Resources.Mocks.NavigationManager());
        ctx.Services.AddScoped(sp => new HttpClient());
        ctx.Services.AddEficazFramework(options =>
        {
            //options.Theme.Palette.Primary = new MudBlazor.Utilities.MudColor("#cacaca");
            //options.Theme.Palette.AppbarBackground = new MudBlazor.Utilities.MudColor("#00ffff");
            options.UseApplicationManager = true;
            options.ThemeIsDarkMode = true;
        });

        ctx.Services.AddOptions();
    }
}
