using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EficazFramework.Application;

[Apartment(System.Threading.ApartmentState.STA)]
public class Events
{

    [SetUp, Apartment(System.Threading.ApartmentState.STA)]
    public void Setup()
    {
        //EficazFramework.Tests.TestContext.MainWindows.WindowState = System.Windows.WindowState.Minimized; // this parameter didn't render the UI :(
        Tests.TestContext.MainWindow.ShowInTaskbar = false;
        Tests.TestContext.Application.MainWindow = EficazFramework.Tests.TestContext.MainWindow;
        Task.Run(() => Tests.TestContext.Application.Run());
    }

    [TearDown]
    public void TearDown()
    {
        EficazFramework.Tests.TestContext.Application?.Properties.Remove("shutdown_requested");
    }

    [Test, Order(1), Apartment(System.Threading.ApartmentState.STA)]
    public async Task ShutDown()
    {
        Tests.TestContext.MainWindow.Show();
        ApplicationEvents.RequestShutDown_Material(EficazFramework.Tests.TestContext.Application?.MainWindow, EficazFramework.Tests.TestContext.Application);
        await Task.Delay(250);
        Tests.TestContext.Application?.Properties["shutdown_requested"].Should().Be(true);
    }

    //[Test, Order(2), Apartment(System.Threading.ApartmentState.STA)]
    public async Task ShutdownByDialog()
    {
        var mock = new EficazFramework.Tests.WPF.Views.Events.DialogTest();
        Tests.TestContext.MainWindow.Content = mock;
        Tests.TestContext.MainWindow.Show();
        Button bt = XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<Button>(Tests.TestContext.MainWindow, "btShutdown");

        Threading.ModalAssist modal = new();

        ApplicationEvents.RequestShutDown_Material(Tests.TestContext.Application?.MainWindow, EficazFramework.Tests.TestContext.Application);
        await Commands.DelayedAction.InvokeAsync(() =>
          {
              //EficazFramework.Tests.Utils.DispatcherUtil.DoEventsSync();
              Tests.Utils.DispatcherUtil.StartSTATask<bool>(() =>
              {
                  bt.RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));
                  modal.Release(EficazFramework.Events.MessageResult.Yes);
                  return true;
              });
          }, 1000);
        var result = await modal.Push();
        result.Should().Be(EficazFramework.Events.MessageResult.Yes);
        Tests.TestContext.Application?.Properties["shutdown_requested_byDialog"].Should().Be(true);
    }
}