
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

namespace EficazFramework.Tests.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class MdiWindowMoveThumb
{

    [TestCase(25, 30)]
    [TestCase(-15, -12)]
    [TestCase(250, 249)]
    [TestCase(3, 6)]
    public void DragAppTest(double left, double top)
    {
        MDIWindowMoveThumb mock = new();
        
        Canvas.SetLeft(mock, 0.0);
        Canvas.SetTop(mock, 0.0);
        Canvas.GetLeft(mock).Should().Be(0);
        Canvas.GetTop(mock).Should().Be(0);
        mock.RaiseEvent(new DragDeltaEventArgs(left, top));
        Canvas.GetLeft(mock).Should().Be(left);
        Canvas.GetTop(mock).Should().Be(top);
    }
}
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.