using AngleSharp.Dom;
using Bunit;
using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Components.Panels;

[TestFixture]
public class SectionsView : BunitTest
{
    [Test]
    public async Task BaseTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.SectionsView>();
        comp.Should().NotBeNull();
        comp.Instance.Should().NotBeNull();
        
        var obj = comp.FindComponents<EficazFramework.Components.SectionsView>()[0];
        obj.Should().NotBeNull();
        obj.Instance.Should().NotBeNull();
        obj.Instance.IsOpen.Should().BeFalse();
        obj.Instance.CurrentSection.Should().Be(0);

        comp.FindAll("div.ef-mdi-sections-menu").Should().BeEmpty();
        await comp.InvokeAsync(() => obj.Instance.ToggleOpen());
        obj.Instance.IsOpen.Should().BeTrue();
        comp.FindAll("div.ef-mdi-sections-menu").Should().NotBeEmpty();
        var sectionsMenu = comp.Find("div.ef-mdi-sections-menu");
        sectionsMenu.Should().NotBeNull();

        await comp.InvokeAsync(() => obj.Instance.ToggleOpen());
        obj.Instance.IsOpen.Should().BeFalse();
        comp.FindAll("div.ef-mdi-sections-menu").Should().BeEmpty();
    }

    [Test]
    public void ButtonTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.SectionsView>();
        var obj = comp.FindComponents<EficazFramework.Components.SectionsView>()[0];

        var button = comp.Find("button.ef-mdi-buttons-toolbar");
        button.Should().NotBeNull();

        obj.Instance.IsOpen.Should().BeFalse();
        button.Click();
        obj.Instance.IsOpen.Should().BeTrue();
        button.Click();
        obj.Instance.IsOpen.Should().BeFalse();
    }

    [Test]
    public async Task SectionHandlingTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.SectionsView>();
        var obj = comp.FindComponents<EficazFramework.Components.SectionsView>()[0];
        await comp.InvokeAsync(() => obj.Instance.ToggleOpen());

        var addButton = comp.Find("button.ef-mdi-sections-add");
        comp.FindAll("button.ef-mdi-sections-clear").Should().BeEmpty();
        obj.Instance.ItemsSource.Should().HaveCount(0);

        addButton.Click();
        obj.Instance.ItemsSource.Should().HaveCount(1);
        obj.Instance.ItemsSource.Last().ID.Should().Be(1);
        obj.Instance.CurrentSection.Should().Be(1);
        comp.FindAll("button.ef-mdi-sections-clear").Should().BeEmpty();

        addButton.Click();
        obj.Instance.ItemsSource.Should().HaveCount(2);
        obj.Instance.ItemsSource.Last().ID.Should().Be(2);
        obj.Instance.CurrentSection.Should().Be(2);
        comp.FindAll("button.ef-mdi-sections-clear").Should().NotBeEmpty();

        addButton.Click();
        obj.Instance.ItemsSource.Should().HaveCount(3);
        obj.Instance.ItemsSource.Last().ID.Should().Be(3);
        obj.Instance.CurrentSection.Should().Be(3);
        comp.FindAll("button.ef-mdi-sections-clear").Should().NotBeEmpty();

        var closeSectionTwoButton = comp.FindAll("button.ef-mdi-sections-close")[1];
        closeSectionTwoButton.Click();
        obj.Instance.ItemsSource.Should().HaveCount(2);
        obj.Instance.ItemsSource.Last().ID.Should().Be(3); //because we've removed Section 2
        obj.Instance.CurrentSection.Should().Be(3); //because we've removed Section 2
        comp.FindAll("button.ef-mdi-sections-clear").Should().NotBeEmpty();

        var clearButton = comp.Find("button.ef-mdi-sections-clear");
        clearButton.Click();
        comp.FindAll("button.ef-mdi-sections-clear").Should().BeEmpty();
        obj.Instance.ItemsSource.Should().HaveCount(0);
        obj.Instance.CurrentSection.Should().Be(0);
    }
}
