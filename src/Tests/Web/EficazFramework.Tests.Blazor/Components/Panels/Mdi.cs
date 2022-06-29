#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída

using Bunit;
using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EficazFramework.Components.Panels;

[TestFixture]
public class Mdi : BunitTest
{
    [Test]
    public void BaseTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Mdi>();
        comp.Find("div.ef-mdi-host").Should().NotBeNull();
        var host = comp.FindComponent<EficazFramework.Components.MdiHost>().Instance;

        //Start Menu Toggle
        host.StartMenuIsOpen.Should().BeFalse();

        var menu = comp.Find("div.mud-popover-cascading-value");
        var popoverContentNode = comp.Find($"#popovercontent-{menu.Id!.Substring(8)}");
        popoverContentNode.Children.Should().BeEmpty();

        comp.InvokeAsync(() => host.ToggleStartMenuOpen());
        host.StartMenuIsOpen.Should().BeTrue();
        comp.FindAll("div.ef-mdi-start-header").Should().HaveCount(1);
        comp.FindAll("div.ef-mdi-start-footer").Should().HaveCount(1);

        //Search for some apps
        comp.FindAll("div.mud-grid-item").Should().HaveCount(10);
        var searchTb = comp.FindComponent<MudBlazor.MudTextField<string>>();
        searchTb.Should().NotBeNull();
        var innerInput = searchTb.Find("input");
        innerInput.Should().NotBeNull();
        comp.InvokeAsync(() =>
        {
            searchTb.Instance.FocusAsync();
            innerInput.Input("new");
            innerInput.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        host.AppSearchFilter.Should().Be("new");
        comp.FindAll("div.mud-grid-item").Should().HaveCount(4);

        //Try StartMenu compact mode
        comp.FindAll("div.mud-list-item").Should().HaveCount(0);
        comp.InvokeAsync(() => host.ToggleStartMenuView());
        comp.FindAll("div.mud-grid-item").Should().HaveCount(0);
        comp.FindAll("div.mud-list-item").Should().HaveCount(5); //4 apps + 1 group (with nested list)
        
        //Clear search (in compact mode)
        comp.InvokeAsync(() =>
        {
            searchTb.Instance.FocusAsync();
            innerInput.Input("");
            innerInput.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        host.AppSearchFilter.Should().Be("");
        comp.FindAll("div.mud-grid-item").Should().HaveCount(0);
        comp.FindAll("div.mud-list-item").Should().HaveCount(12); //10 apps + 2 groups

        //Close the start menu clicking outside it
        comp.InvokeAsync(() => host.ToggleStartMenuOpen(true));
        host.StartMenuIsOpen.Should().BeFalse();
    }

    [Test]
    public void RunPublicApplicationTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Mdi>();
        var host = comp.FindComponent<EficazFramework.Components.MdiHost>().Instance;

        
    }
}
