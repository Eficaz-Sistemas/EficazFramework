﻿
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
        //host.StartMenuIsOpen.Should().BeFalse();

        var menu = comp.Find("div.mud-popover-cascading-value");
        var popoverContentNode = comp.Find($"#popovercontent-{menu.Id![8..]}");
        popoverContentNode.Children.Should().BeEmpty();

        //comp.InvokeAsync(() => host.ToggleStartMenuOpen());
        //host.StartMenuIsOpen.Should().BeTrue();
        //comp.FindAll("div.ef-mdi-start-header").Should().HaveCount(1);
        //comp.FindAll("div.ef-mdi-start-footer").Should().HaveCount(1);

        //Search for some apps
        comp.FindAll("div.mud-grid-item").Should().HaveCount(11);
        var searchTb = comp.FindComponent<MudBlazor.MudTextField<string>>();
        searchTb.Should().NotBeNull();
        var innerInput = searchTb.Find("input");
        innerInput.Should().NotBeNull();
        //comp.InvokeAsync(() =>
        //{
        //    searchTb.Instance.FocusAsync();
        //    innerInput.Input("new");
        //    innerInput.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        //});
        //host.AppSearchFilter.Should().Be("new");
        comp.FindAll("div.mud-grid-item").Should().HaveCount(5);

        //Try StartMenu compact mode
        //comp.FindAll("div.mud-list-item").Should().HaveCount(0);
        //comp.InvokeAsync(() => host.ToggleStartMenuView());
        comp.FindAll("div.mud-grid-item").Should().HaveCount(0);
        comp.FindAll("div.mud-list-item").Should().HaveCount(7); //5 apps + 2 groups (with nested list)
        
        //Clear search (in compact mode)
        //comp.InvokeAsync(() =>
        //{
        //    searchTb.Instance.FocusAsync();
        //    innerInput.Input("");
        //    innerInput.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        //});
        //host.AppSearchFilter.Should().Be("");
        comp.FindAll("div.mud-grid-item").Should().HaveCount(0);
        comp.FindAll("div.mud-list-item").Should().HaveCount(13); //11 apps + 2 groups

        //Close the start menu clicking outside it
        //comp.InvokeAsync(() => host.ToggleStartMenuOpen(true));
        //host.StartMenuIsOpen.Should().BeFalse();
    }

    [Test]
    public void RunPublicApplicationTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Mdi>();
        var host = comp.FindComponent<EficazFramework.Components.MdiHost>().Instance;

        
    }
}
