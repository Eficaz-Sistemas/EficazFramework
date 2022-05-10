using NUnit.Framework;
using FluentAssertions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Threading;
using XamlTest;

namespace EficazFramework.Tests.Controls.Extensions;
public class ButtonExtensionsTests : BaseTest
{
    [Test]
    [Apartment(ApartmentState.STA)]
    public void IconSizeTest()
    {
        var button = new Button();
        EficazFramework.Controls.AttachedProperties.Button.GetIconSize(button).Should().Be(20d);
        EficazFramework.Controls.AttachedProperties.Button.SetIconSize(button, 30d);
        EficazFramework.Controls.AttachedProperties.Button.GetIconSize(button).Should().Be(30d);
    }

    [Test]
    public async Task MouseOverBackgroundBrushTest()
    {
        var tabControl = await MainWindow.GetElement<TabControl>("maintab");
        tabControl.Should().NotBeNull();
        await tabControl.SetSelectedIndex(1);

        var button = await tabControl.GetElement<Button>("TEST_Button_0");
        button.Should().NotBeNull();
        (await button.GetProperty<string>("Name")).Should().Be("TEST_Button_0");

        var primary = (await MainWindow.GetResource("Color.Primary.Background")).GetAs<Color?>() ?? throw new System.Exception($"Failed to convert resource 'Color.Primary.Background' to color");
        (await button.GetEffectiveBackground()).Should().Be(primary);
      

    }
}
