using AngleSharp.Dom;
using Bunit;
using EficazFramework.Tests;
using AwesomeAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Components.Panels;

[TestFixture]
public class ApplicationsMenu : BunitTest
{
    [Test]
    public void BaseTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.ApplicationsMenu>();
        comp.Should().NotBeNull();
        comp.Instance.Should().NotBeNull();
        comp.Instance.BoundSearchFilter.Should().BeNullOrEmpty();

        var obj = comp.FindComponent<EficazFramework.Components.ApplicationsMenu>();
        obj.Should().NotBeNull();
        obj.Instance.Should().NotBeNull();
        obj.Instance.SearchFilter.Should().BeNullOrEmpty();

        var items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().HaveCount(obj.Instance.ItemsSource.Count());
    }

    [Test]
    public async Task ViewModeTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.ApplicationsMenu>();
        var obj = comp.FindComponent<EficazFramework.Components.ApplicationsMenu>();
        var groupCount = obj.Instance.ItemsSource.GroupBy(g => g.Group).Count();

        var items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().HaveCount(obj.Instance.ItemsSource.Count());
        var listItems = comp.FindComponents<MudBlazor.MudListItem<IGrouping<string, EficazFramework.Application.ApplicationDefinition>>>();
        listItems.Should().BeEmpty();

        await comp.InvokeAsync(() => obj.Instance.ToggleHostView());

        items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().BeEmpty();
        listItems = comp.FindComponents<MudBlazor.MudListItem<IGrouping<string, EficazFramework.Application.ApplicationDefinition>>>();
        listItems.Should().HaveCount(obj.Instance.ItemsSource.Count() + groupCount);
    }

    [Test]
    public void ViewModeByButtonTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.ApplicationsMenu>();
        var obj = comp.FindComponent<EficazFramework.Components.ApplicationsMenu>();
        var groupCount = obj.Instance.ItemsSource.GroupBy(g => g.Group).Count();

        var items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().HaveCount(obj.Instance.ItemsSource.Count());
        var listItems = comp.FindComponents<MudBlazor.MudListItem<IGrouping<string, EficazFramework.Application.ApplicationDefinition>>>();
        listItems.Should().BeEmpty();

        var button = comp.Find("button.ef-buttons-togglehost");
        button.Should().NotBeNull();
        button.Click();

        items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().BeEmpty();
        listItems = comp.FindComponents<MudBlazor.MudListItem<IGrouping<string, EficazFramework.Application.ApplicationDefinition>>>();
        listItems.Should().HaveCount(obj.Instance.ItemsSource.Count() + groupCount);
    }

    [Test]
    public void FilterBindingTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.ApplicationsMenu>();
        var obj = comp.FindComponent<EficazFramework.Components.ApplicationsMenu>();

        var items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().HaveCount(obj.Instance.ItemsSource.Count());

        comp.Instance.BoundSearchFilter = "1";
        comp.Render();
        obj.Instance.SearchFilter.Should().Be("1");

        items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().HaveCountLessThan(obj.Instance.ItemsSource.Count());


    }

    [Test]
    public async Task FilterTypingTest()
    {
        var comp = Context.Render<Tests.Blazor.Views.Pages.Components.Panels.ApplicationsMenu>();
        var obj = comp.FindComponent<EficazFramework.Components.ApplicationsMenu>();

        var items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().HaveCount(obj.Instance.ItemsSource.Count());

        var tbox = comp.FindComponent<MudBlazor.MudTextField<string>>();
        await comp.InvokeAsync(() => tbox.Instance.SetText("1"));

        items = comp.FindComponents<MudBlazor.MudItem>();
        items.Should().HaveCountLessThan(obj.Instance.ItemsSource.Count());
    }

}
