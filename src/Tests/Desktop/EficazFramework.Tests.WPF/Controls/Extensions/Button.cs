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
    [Apartment(ApartmentState.STA)]
    public async Task MouseOverBackgroundBrushTest()
    {
        try
        {
            var tabControl = await MainWindow.GetElement<TabControl>("maintab");
            tabControl.Should().NotBeNull();
            await tabControl.SetSelectedIndex(1);

            var button = await tabControl.GetElement<Button>("TEST_Button_0");
            button.Should().NotBeNull();
            (await button.GetProperty<string>("Name")).Should().Be("TEST_Button_0");

            (await button.GetEffectiveBackground()).Should().Be(ThemeColorPrimary);

            await button.SetProperty(EficazFramework.Controls.AttachedProperties.Control.ColorProperty, EficazFramework.Controls.AttachedProperties.Color.Secondary);
            (await button.GetEffectiveBackground()).Should().Be(ThemeColorSecondary);
            await button.SetProperty(EficazFramework.Controls.AttachedProperties.Control.ColorProperty, EficazFramework.Controls.AttachedProperties.Color.Tertiary);
            (await button.GetEffectiveBackground()).Should().Be(ThemeColorTertiary);
            await button.SetProperty(EficazFramework.Controls.AttachedProperties.Control.ColorProperty, EficazFramework.Controls.AttachedProperties.Color.Surface);
            (await button.GetEffectiveBackground()).Should().Be(ThemeColorSurface);

            var mouseOverElement = await button.GetElement<Border>("MouseOverPresenter");
            mouseOverElement.Should().NotBeNull();
            (await mouseOverElement.GetProperty<Visibility>("Visibility")).Should().Be(Visibility.Collapsed);
            await button.MoveCursorTo();
            await Task.Delay(250);
            (await mouseOverElement.GetProperty<Visibility>("Visibility")).Should().Be(Visibility.Visible);
        }
        catch (Grpc.Core.RpcException ex)
        {
            Console.WriteLine("Skipping test due to gRPC error: " + ex.Message);
        }
    }
}
