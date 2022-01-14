
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
        Controls.MDIWindow? app1 = (Controls.MDIWindow)mock?.Container.ItemContainerGenerator.ContainerFromItem(mock?.ItemsSource[0]);
        Canvas.GetLeft(app1).Should().Be(0);
        Canvas.GetTop(app1).Should().Be(0);
        app1?.UpdateLayout();
        app1?.Header.Should().NotBeNull();
        app1?.ApplyTemplate();

        XAML.Behaviors.MDIWindowMoveThumb th = XAML.Utilities.VisualTreeHelpers.FindVisualChild<XAML.Behaviors.MDIWindowMoveThumb>(app1);
        th.Should().NotBeNull();
        th.RaiseEvent(new DragDeltaEventArgs(25, 30));
        Canvas.GetLeft(app1).Should().Be(25);
        Canvas.GetTop(app1).Should().Be(30);
    }
}
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.