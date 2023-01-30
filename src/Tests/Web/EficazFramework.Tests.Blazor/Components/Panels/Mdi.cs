
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
    public void RunPublicApplicationTest()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Mdi>();
        var host = comp.FindComponent<EficazFramework.Components.MdiHost>().Instance;

        host.CurrentSection.Should().Be(0);
        EficazFramework.Application.IApplicationManager.Instance!.SectionManager.CurrentSectionId.Should().Be(0);
        EficazFramework.Application.IApplicationManager.Instance!.RunningApplications.Should().BeEmpty();

    }
}
