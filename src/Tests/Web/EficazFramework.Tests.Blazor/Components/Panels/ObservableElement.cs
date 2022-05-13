#pragma warning disable BL0005 // Component parameter should not be set outside of its component.

using Bunit;
using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EficazFramework.Components.Panels;

[TestFixture]
public class ObservableElement : BunitTest
{
    [Test]
    public async Task ObserveTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.ObservableElement>();
        comp.Find("h2").ToMarkup().Should().NotContain("on-screen");
        comp.Find("h3").ToMarkup().Should().NotContain("on-screen");

        var buttons = comp.FindAll("button");
        buttons.Should().HaveCount(4); //should include mudFab inside MudScrollToTop

        await comp.InvokeAsync(() => buttons[0].Click());
    }
}
