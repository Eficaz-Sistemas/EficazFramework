using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EficazFramework.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class DataGridAssist
{

    [SetUp]
    public void Setup()
    {
        //EficazFramework.Tests.TestContext.MainWindows.WindowState = System.Windows.WindowState.Minimized; // this parameter didn't render the UI :(
        Tests.TestContext.MainWindow.ShowInTaskbar = false;
        Tests.TestContext.Application.MainWindow = new();
        Task.Run(() => Tests.TestContext.Application.Run());
    }

    [TearDown]
    public void TearDown()
    {
    }

    [Test, Order(1)]
    public async Task NavigationTemplateTest()
    {
        Tests.TestContext.Application.MainWindow.Content = new Tests.WPF.Views.Behaviors.DataGridNavigation();
        Tests.TestContext.Application.MainWindow.Show();
        //Threading.ModalAssist modal = new();
        //var result = await modal.Push();
    }

}