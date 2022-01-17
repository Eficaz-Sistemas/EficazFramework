
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

namespace EficazFramework.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class TextBoxAssistTests
{
    EficazFramework.Tests.WPF.Views.Behaviors.Inputs mock = null;


    [SetUp]
    public void Setup()
    {
        mock = new();
        Tests.TestContext.MainWindow.Content = mock;
        Tests.TestContext.Application?.MainWindow.Show();
        Tests.TestContext.Application?.MainWindow.UpdateLayout();
    }

    [Test]
    public void SelectOnFocusTest()
    {
        mock.UpdateLayout();
        mock.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        mock.TextBox1.Focus();
        mock.TextBox1.IsFocused.Should().BeTrue();
        mock.TextBox1.SelectionStart.Should().Be(0);
        mock.TextBox1.SelectionLength.Should().Be(0);
        mock.TextBox2.IsFocused.Should().BeFalse();
        mock.CNPJMaskedTextBox.IsFocused.Should().BeFalse();
        mock.DateMaskedTextBox.IsFocused.Should().BeFalse();

        mock.TextBox2.SelectionLength = 0;
        mock.TextBox2.Focus();
        mock.TextBox1.IsFocused.Should().BeFalse();
        mock.TextBox2.IsFocused.Should().BeTrue();
        mock.TextBox2.SelectionStart.Should().Be(0);
        mock.TextBox2.SelectionLength.Should().Be(6);
        mock.CNPJMaskedTextBox.IsFocused.Should().BeFalse();
        mock.DateMaskedTextBox.IsFocused.Should().BeFalse();

        mock.TextBox1.Focus();
        mock.TextBox2.SelectionLength = 0;
        EficazFramework.XAML.Behaviors.TextBox.SetSelectAllOnFocus(mock.TextBox2, false);
        mock.TextBox2.Focus();
        mock.TextBox2.SelectionStart.Should().Be(0);
        mock.TextBox2.SelectionLength.Should().Be(0);

        mock.TextBox1.Focus();
        EficazFramework.XAML.Behaviors.TextBox.SetSelectAllOnFocus(mock.TextBox2, true);
        mock.TextBox2.Focus();
        mock.TextBox2.SelectionStart.Should().Be(0);
        mock.TextBox2.SelectionLength.Should().Be(6);
    }
}
