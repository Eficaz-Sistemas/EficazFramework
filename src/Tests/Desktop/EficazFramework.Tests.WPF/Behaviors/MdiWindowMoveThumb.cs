
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
    Tests.WPF.Views.Behaviors.MdiWindowThumb mock = new();
    System.Windows.Window win = new();

    [SetUp]
    public void Setup()
    {
        win = new();
        win.Content = mock;
        win.Show();
    }

    [TearDown]
    public void TearDown()
    {
        win.Close();
    }

    [Test]
    public void MouseDown()
    {
        mock?.Win1.ApplyTemplate();
        mock?.Win1.IsSelected.Should().BeFalse();
        mock?.Win1.IsKeyboardFocusWithin.Should().BeFalse();
        MouseButtonEventArgs eventArg = new(InputManager.Current.PrimaryMouseDevice, 1, MouseButton.Left);
        eventArg.RoutedEvent = MDIWindowMoveThumb.MouseLeftButtonDownEvent;
        MDIWindowMoveThumb header = XAML.Utilities.VisualTreeHelpers.FindVisualChild<MDIWindowMoveThumb>(mock?.Win1);
        header.RaiseEvent(eventArg);
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