
using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using EficazFramework.XAML.Behaviors;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls.Primitives;

#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.

namespace EficazFramework.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class MdiWindowMoveThumb
{
    Tests.WPF.Views.Behaviors.MdiWindowThumb? mock = null;

    [SetUp]
    public void Setup()
    {
        mock = new();
        Tests.TestContext.Application.MainWindow.Content = mock;
        Tests.TestContext.Application.MainWindow.Show();
    }

    [Test]  
    public void DragAppTest()
    {
        Canvas.GetLeft(mock?.App1).Should().Be(50);
        Canvas.GetTop(mock?.App1).Should().Be(50);
        mock?.App1.RaiseEvent(new DragDeltaEventArgs(25, 30));
        Canvas.GetLeft(mock?.App1).Should().Be(75);
        Canvas.GetTop(mock?.App1).Should().Be(80);
    }
}
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.