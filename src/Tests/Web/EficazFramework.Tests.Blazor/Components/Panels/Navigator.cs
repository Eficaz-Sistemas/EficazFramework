#pragma warning disable BL0005 // Component parameter should not be set outside of its component.

using Bunit;
using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EficazFramework.Components.Panels;

[TestFixture]
public class Navigator : BunitTest
{
    [Test]  
    public async Task NavigationTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Navigator>();
        comp.Markup.Should().Contain("Page A");
        comp.Markup.Should().Contain("Next");

        var button = comp.Find("button");
        await comp.InvokeAsync(() => button.Click());

        comp.Markup.Should().Contain("Page B");
        comp.Markup.Should().Contain("Previous");

        button = comp.Find("button");
        await comp.InvokeAsync(() => button.Click());

        comp.Markup.Should().Contain("Page A");
        comp.Markup.Should().Contain("Next");
    }
}
