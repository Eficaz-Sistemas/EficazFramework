using EficazFramework.XAML.Behaviors;
using System.Windows.Controls.Primitives;

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