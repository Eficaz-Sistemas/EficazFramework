namespace EficazFramework.Tests.Controls.Extensions;

public class ControlExtensionsTests : BaseTest
{
    [Test]
    [Apartment(ApartmentState.STA)]
    public void PasswordBoxTipTextTest()
    {
        var passwordBox = new PasswordBox();
        passwordBox.Password.Should().BeEmpty();
        EficazFramework.Controls.AttachedProperties.Control.GetTipText(passwordBox).Should().BeNull();
        EficazFramework.Controls.AttachedProperties.Control.GetIsEmpty(passwordBox).Should().BeTrue();

        passwordBox.Password = "test";
        EficazFramework.Controls.AttachedProperties.Control.GetTipText(passwordBox).Should().BeNull();
        EficazFramework.Controls.AttachedProperties.Control.GetIsEmpty(passwordBox).Should().BeTrue();

        passwordBox.Password = "";
        EficazFramework.Controls.AttachedProperties.Control.SetTipText(passwordBox, "test");
        EficazFramework.Controls.AttachedProperties.Control.GetIsEmpty(passwordBox).Should().BeTrue();

        passwordBox.Password = "test";
        EficazFramework.Controls.AttachedProperties.Control.GetIsEmpty(passwordBox).Should().BeFalse();

        passwordBox.Password = "";
        EficazFramework.Controls.AttachedProperties.Control.GetIsEmpty(passwordBox).Should().BeTrue();

        EficazFramework.Controls.AttachedProperties.Control.SetTipText(passwordBox, String.Empty);
        EficazFramework.Controls.AttachedProperties.Control.GetIsEmpty(passwordBox).Should().BeTrue();

        passwordBox.Password = "test";
        EficazFramework.Controls.AttachedProperties.Control.GetIsEmpty(passwordBox).Should().BeTrue();

    }
}
