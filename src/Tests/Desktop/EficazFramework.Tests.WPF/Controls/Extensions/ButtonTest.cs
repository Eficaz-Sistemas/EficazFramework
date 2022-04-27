using NUnit.Framework;
using FluentAssertions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace EficazFramework.Tests.Controls.Extensions;
public class ButtonExtensionsTests : BaseTest
{
    [Test]
    public void IconSizeTest()
    {
        var button = new Button();
        EficazFramework.Controls.AttachedProperties.Button.GetIconSize(button).Should().Be(20d);
        EficazFramework.Controls.AttachedProperties.Button.SetIconSize(button, 30d);
        EficazFramework.Controls.AttachedProperties.Button.GetIconSize(button).Should().Be(30d);
    }

    [Test]
    public void MouseOverBackgroundBrushTest()
    {
        // setup UI
        //MainWindow.tabsMain.SelectedIndex = 1;
        //var button = MainWindow.TEST_Button_0;

        //// setup test
        //EficazFramework.Controls.AttachedProperties.Button.GetMouseOver(button).Should().BeNull();
        //EficazFramework.Controls.AttachedProperties.Button.SetMouseOver(button, new SolidColorBrush(Colors.Red));
        //EficazFramework.Controls.AttachedProperties.Button.GetMouseOver(button).Should().BeOfType<SolidColorBrush>();
        //((SolidColorBrush)EficazFramework.Controls.AttachedProperties.Button.GetMouseOver(button)).Color.Should().Be(Colors.Red);

    }
}
