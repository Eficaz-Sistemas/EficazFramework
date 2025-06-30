using Bunit;
using EficazFramework.Tests;
using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.Template;

[TestFixture]
public class CookieConsent : BunitTest
{
    [Test]
    public void TestInitialization()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Templates.CookieConsent>();
        //Console.WriteLine(comp.Markup);
        //comp.Find("div.mud-snackbar").Should().NotBeNull();

        var cookieConsent = comp.FindComponent<EficazFramework.Templates.CookieConsent>();
        cookieConsent.Should().NotBeNull();
        cookieConsent.Instance.HasCookieConsent.Should().BeFalse();

    }
}
