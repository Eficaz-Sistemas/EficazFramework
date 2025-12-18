using AngleSharp.Dom;
using Bunit;
using EficazFramework.Tests;
using AwesomeAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Components.Panels;

[TestFixture]
public class StartMenu : BunitTest
{
    [Test]
    public async Task BaseTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.StartMenu>();
        comp.Should().NotBeNull();
        comp.Instance.Should().NotBeNull();

        var obj = comp.FindComponent<EficazFramework.Components.StartMenu>();
        obj.Should().NotBeNull();
        obj.Instance.Should().NotBeNull();

        comp.FindAll("div.ef-mdi-startmenu").Should().BeEmpty();
        await comp.InvokeAsync(() => obj.Instance.ToggleOpen());
        obj.Instance.IsOpen.Should().BeTrue();
        comp.FindAll("div.ef-mdi-startmenu").Should().NotBeEmpty();
        var sectionsMenu = comp.Find("div.ef-mdi-startmenu");
        sectionsMenu.Should().NotBeNull();

        await comp.InvokeAsync(() => obj.Instance.ToggleOpen());
        obj.Instance.IsOpen.Should().BeFalse();
        comp.FindAll("div.ef-mdi-startmenu").Should().BeEmpty();
    }

    [Test]
    public void ButtonTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.StartMenu>();
        var obj = comp.FindComponent<EficazFramework.Components.StartMenu>();

        var button = comp.Find("button.ef-mdi-buttons-toolbar");
        button.Should().NotBeNull();

        obj.Instance.IsOpen.Should().BeFalse();
        button.Click();
        obj.Instance.IsOpen.Should().BeTrue();
        button.Click();
        obj.Instance.IsOpen.Should().BeFalse();
    }

    [Test]
    public async Task HeaderTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.StartMenu>();
        var obj = comp.FindComponent<EficazFramework.Components.StartMenu>();
        obj.Instance.ShowHeader.Should().BeTrue();

        comp.FindAll("div.ef-mdi-startmenu").Should().BeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-header").Should().BeEmpty();

        await comp.InvokeAsync(() => obj.Instance.ToggleOpen());
        comp.FindAll("div.ef-mdi-startmenu").Should().NotBeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-header").Should().NotBeEmpty();

        await comp.InvokeAsync(() => comp.Instance._showHeader = false);
        comp.Render();
        comp.FindAll("div.ef-mdi-startmenu").Should().NotBeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-header").Should().BeEmpty();
        obj.Instance.ShowHeader.Should().BeFalse();

        await comp.InvokeAsync(() => comp.Instance._showHeader = true);
        comp.Render();
        comp.FindAll("div.ef-mdi-startmenu").Should().NotBeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-header").Should().NotBeEmpty();
        obj.Instance.ShowHeader.Should().BeTrue();
    }

    [Test]
    public async Task FooterTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.StartMenu>();
        var obj = comp.FindComponent<EficazFramework.Components.StartMenu>();
        obj.Instance.ShowFooter.Should().BeTrue();

        comp.FindAll("div.ef-mdi-startmenu").Should().BeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-footer").Should().BeEmpty();

        await comp.InvokeAsync(() => obj.Instance.ToggleOpen());
        comp.FindAll("div.ef-mdi-startmenu").Should().NotBeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-footer").Should().NotBeEmpty();

        await comp.InvokeAsync(() => comp.Instance._showFooter = false);
        comp.Render();
        comp.FindAll("div.ef-mdi-startmenu").Should().NotBeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-footer").Should().BeEmpty();
        obj.Instance.ShowFooter.Should().BeFalse();

        await comp.InvokeAsync(() => comp.Instance._showFooter = true);
        comp.Render();
        comp.FindAll("div.ef-mdi-startmenu").Should().NotBeEmpty();
        comp.FindAll("div.ef-mdi-startmenu-footer").Should().NotBeEmpty();
        obj.Instance.ShowFooter.Should().BeTrue();
    }

}
