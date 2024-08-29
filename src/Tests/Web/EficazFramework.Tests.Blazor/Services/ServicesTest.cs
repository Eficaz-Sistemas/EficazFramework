using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.Services;

[TestFixture]
public class ServicesTest : BunitTest
{
    [Test]
    public void Test()
    {
        // Arrange
        Context.Services.AddEficazFramework(o =>
        {
            o.UseApplicationManager = true;
            o.Theme = new MudBlazor.MudTheme()
            {
                PaletteLight = new MudBlazor.PaletteLight()
                {
                    Primary = "#0078d7",
                    Secondary = "#003864",
                    AppbarBackground = "#0078d7",
                    AppbarText = "#fff",
                },
                PaletteDark = new MudBlazor.PaletteDark()
                {
                    Primary = "#0078d7",
                    Secondary = "#003864",
                    AppbarBackground = "#0078d7",
                    AppbarText = "#fff",
                }
            };
        });

        Context.Services.GetService<EficazFramework.Application.IApplicationManager>().Should().NotBeNull();
        Context.Services.GetService<EficazFramework.Services.IThemeProvider>().Should().NotBeNull();
    }
}
