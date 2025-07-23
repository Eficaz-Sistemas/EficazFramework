#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída

using AngleSharp.Dom;
using AwesomeAssertions;
using Bunit;
using EficazFramework.Tests;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MudBlazor;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Components.Dialogs;
[TestFixture]
public class ViewModelDialog : BunitTest
{
    [Test]
    public async Task TestDialog()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Dialogs.ViewModelDialog>();

        comp.FindAll("div.mud-dialog-container").Count.Should().Be(0); // init closed
        comp.FindAll("div.mud-dialog-title").Count.Should().Be(0); // init closed
        comp.FindAll("div.mud-dialog-content").Count.Should().Be(0); // init closed
        comp.FindAll("div.mud-dialog-actions").Count.Should().Be(0); // init closed

        // opening dialog - OK button
        Task.Delay(5000).ContinueWith(t =>
        {
            return true;
        });

        var buttons = comp.FindAll("button");
        comp.Instance.ShowDialog();
        await Task.Delay(5000);

    }

    [Test]
    public async Task MdiTestDialog()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Panels.Mdi>();
        var hostRenderer = comp.FindComponent<EficazFramework.Components.MdiHost>();
        var host = hostRenderer.Instance;
        host.Should().NotBeNull();

        var app = EficazFramework.Application.IApplicationManager.Instance!.AllApplications
            .Where(manifest => manifest.Title == "My App 1").SingleOrDefault();
        app.Should().NotBeNull();

        hostRenderer.InvokeAsync(() => host.LoadApplication(app!));
        hostRenderer.WaitForElement("div.ef-mdi-window-maximized", System.TimeSpan.FromMilliseconds(1000));
        var windowRenderer = hostRenderer.FindComponent<EficazFramework.Components.MdiWindow>();
        var window = windowRenderer.Instance;
        window.ApplicationInstance.Title.Should().Be("My App 1");


        System.Action compFindAction = () => comp.Find("div.ef-dialog");
        compFindAction.Should().Throw<Bunit.ElementNotFoundException>();

        IRefreshableElementCollection<IElement> _buttons() => windowRenderer.FindAll("button.mud-button-root");
        IElement dlgButton = _buttons()[1];
        windowRenderer.InvokeAsync(async() => await dlgButton.ClickAsync(new MouseEventArgs()));

        hostRenderer.WaitForElement("div.mud-overlay-dialog", System.TimeSpan.FromMilliseconds(1000)); // now open
    }
}