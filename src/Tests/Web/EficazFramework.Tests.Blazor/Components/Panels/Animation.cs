#pragma warning disable BL0005 // Component parameter should not be set outside of its component.

using Bunit;
using EficazFramework.Tests;
using AwesomeAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EficazFramework.Components.Panels;

[TestFixture]
public class Animation : BunitTest
{
    [Test]
    public void AnimateOnRenderTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Animation>();
        comp.Find("div.obj001")?.Attributes["style"]?.Value.Should().Contain("animation:fadeInLeft 0.5s linear 0s normal");
        comp.Find("div.obj002")?.Attributes["style"]?.Value.Should().Contain("animation:fadeIn 1s linear 0s normal");
        comp.Find("div.obj003")?.Attributes["style"]?.Value.Should().Contain("animation:fadeInDown 1.5s linear 0s normal");
        comp.Find("div.obj004")?.Attributes["style"]?.Value.Should().Contain("animation:fadeInUp 2s linear 0s normal");
    }

    [Test]
    public async Task AnimateExplicityTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Animation>();
        comp.Find("div.obj005")?.Attributes["style"]?.Value.Should().Be(string.Empty);
        var obj005 = comp.FindComponents<EficazFramework.Components.Animation>()[4];
        obj005.Instance.Trigger.Should().Be(Enums.AnimationTrigger.Explicity);
        await comp.InvokeAsync(() => obj005.Instance.Animate());
        comp.Find("div.obj005")?.Attributes["style"]?.Value.Should().Contain("animation:fadeInRight 0.75s linear 0s normal");

        await comp.InvokeAsync(() =>
        {
            obj005.Instance.IsLocked = true;
            obj005.Instance.Trigger = Enums.AnimationTrigger.OnRender;
            obj005.Instance.TimmingFunction = Enums.AnimationTimmingFunc.ease_in;
            obj005.Instance.Infinite = true;
        });
        comp.Find("div.obj005")?.Attributes["style"]?.Value.Should().Be(string.Empty);
        await comp.InvokeAsync(() =>
        {
            obj005.Instance.IsLocked = false;
        });
        comp.Find("div.obj005")?.Attributes["style"]?.Value.Should().Contain("animation:fadeInRight 0.75s ease-in 0s infinite normal");
    }
}
