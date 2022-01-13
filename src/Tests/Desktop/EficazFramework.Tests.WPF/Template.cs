using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EficazFramework.Tests;

[Apartment(System.Threading.ApartmentState.STA)]
public class Template
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
    public void Test1()
    {
        Tests.TestContext.Application.MainWindow.Content = null; //TODO
        Tests.TestContext.Application.MainWindow.Show();
    }

}