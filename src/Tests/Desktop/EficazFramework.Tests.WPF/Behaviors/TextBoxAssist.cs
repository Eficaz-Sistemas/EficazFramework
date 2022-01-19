
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
using System;

namespace EficazFramework.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class TextBoxAssistTests
{
    System.Windows.Window win = new();
    EficazFramework.Tests.WPF.Views.Behaviors.Inputs mock = new();


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

    [Test, Order(1)]
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
        EficazFramework.XAML.Behaviors.TextBox.GetSelectAllOnFocus(mock.TextBox2).Should().BeTrue();
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

        //non TextBox usings:
        Action setOnAnotherType = () => EficazFramework.XAML.Behaviors.TextBox.SetSelectAllOnFocus(mock, true);
    }

    [Test, Order(2)]
    public void InputMaskTypingTest()
    {
        //full text test
        var bh = (TextBoxInputMaskBehavior)Microsoft.Xaml.Behaviors.Interaction.GetBehaviors(mock.CNPJMaskedTextBox).First();
        mock.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        mock.CNPJMaskedTextBox.Text = "04486184000100";
        mock.CNPJMaskedTextBox.Text.Should().Be("04.486.184/0001-00");

        // clearing test
        mock.CNPJMaskedTextBox.Text = "";
        mock.CNPJMaskedTextBox.Text.Should().Be("__.___.___/____-__");

        // user typing test
        mock.CNPJMaskedTextBox.Text = "";
        mock.CNPJMaskedTextBox.SelectionStart = 0;
        mock.CNPJMaskedTextBox.SelectionLength = 0;
        mock.CNPJMaskedTextBox.ScrollToHome();

        // Key.A
        TextCompositionEventArgs eventArgs = new(Keyboard.PrimaryDevice,
                                                 new TextComposition(InputManager.Current,
                                                                     mock.CNPJMaskedTextBox,
                                                                     "A"));
        eventArgs.RoutedEvent = System.Windows.Controls.TextBox.PreviewTextInputEvent;
        mock.CNPJMaskedTextBox.RaiseEvent(eventArgs); // refuse
        mock.CNPJMaskedTextBox.Text.Should().Be("__.___.___/____-__");

        // Key.Number3
        eventArgs = new(Keyboard.PrimaryDevice,
                    new TextComposition(InputManager.Current,
                                        mock.CNPJMaskedTextBox,
                                        "3"));
        eventArgs.RoutedEvent = System.Windows.Controls.TextBox.PreviewTextInputEvent;
        mock.CNPJMaskedTextBox.RaiseEvent(eventArgs); // accept
        mock.CNPJMaskedTextBox.Text.Should().Be("3_.___.___/____-__");

        // Key.Number0
        eventArgs = new(Keyboard.PrimaryDevice,
                    new TextComposition(InputManager.Current,
                                        mock.CNPJMaskedTextBox,
                                        "0"));
        eventArgs.RoutedEvent = System.Windows.Controls.TextBox.PreviewTextInputEvent;
        mock.CNPJMaskedTextBox.RaiseEvent(eventArgs); // accept
        mock.CNPJMaskedTextBox.Text.Should().Be("30.___.___/____-__");

        // Key.dot
        eventArgs = new(Keyboard.PrimaryDevice,
                    new TextComposition(InputManager.Current,
                                        mock.CNPJMaskedTextBox,
                                        "."));
        eventArgs.RoutedEvent = System.Windows.Controls.TextBox.PreviewTextInputEvent;
        mock.CNPJMaskedTextBox.RaiseEvent(eventArgs); // no action
        mock.CNPJMaskedTextBox.Text.Should().Be("30.___.___/____-__");

        mock.CNPJMaskedTextBox.RaiseEvent(eventArgs); // again, no action
        mock.CNPJMaskedTextBox.Text.Should().Be("30.___.___/____-__");

    }

    [Test, Order(3)]
    public void InputMaskPastingTest()
    {
        //full text test
        var bh = (TextBoxInputMaskBehavior)Microsoft.Xaml.Behaviors.Interaction.GetBehaviors(mock.CNPJMaskedTextBox).First();
        mock.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

        DataObjectPastingEventArgs args = new(new DataObject("04486184000100"), false, DataFormats.Text) { RoutedEvent = DataObject.PastingEvent};
        mock.CNPJMaskedTextBox.Text = "";
        mock.CNPJMaskedTextBox.Text.Should().Be("__.___.___/____-__");
        mock.CNPJMaskedTextBox.SelectionStart = 0;
        mock.CNPJMaskedTextBox.SelectionLength = 0;
        mock.CNPJMaskedTextBox.RaiseEvent(args);
        mock.CNPJMaskedTextBox.Text.Should().Be("04.486.184/0001-00");
    }

}
