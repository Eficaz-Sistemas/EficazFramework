using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using EficazFramework.XAML.Behaviors;
using System.Windows;

namespace EficazFramework.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class DataGridAssist
{

    [SetUp]
    public void Setup()
    {
        //EficazFramework.Tests.TestContext.MainWindows.WindowState = System.Windows.WindowState.Minimized; // this parameter didn't render the UI :(
        Tests.TestContext.MainWindow.ShowInTaskbar = false;
    }

    [TearDown]
    public void TearDown()
    {
        Tests.TestContext.MainWindow.Close();
    }

    [Test, Order(1)]
    public void NavigationTemplateTest()
    {
        Tests.WPF.Views.Behaviors.DataGridNavigation mock = new();
        Tests.TestContext.Application.MainWindow.Content = mock;
        Tests.TestContext.Application.MainWindow.Show();

        mock.DataGridInstance.Items.Count.Should().Be(mock.DataGridInstance.Items.Count);
        
        mock.DataGridInstance.SelectAndFocusCell(0, mock.ItemsSource.Single(e => e.Name == "Blog 2"));
        mock.DataGridInstance.IsKeyboardFocusWithin.Should().BeTrue();
        
        mock.ItemsSource.IndexOf((Resources.Mocks.Classes.Blog)mock.DataGridInstance.CurrentCell.Item).Should().Be(2);
        mock.DataGridInstance.CurrentCell.Item.Should().Be(mock.ItemsSource[2]);
        mock.DataGridInstance.CurrentCell.Column.DisplayIndex.Should().Be(0);
        ((DataGridRow)mock.DataGridInstance.ItemContainerGenerator.ContainerFromIndex(2)).IsEditing.Should().BeTrue();

        //move to next column
        var focused = Keyboard.FocusedElement;
        mock.DataGridInstance.RaiseEvent(new System.Windows.Input.KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual((System.Windows.Media.Visual)focused), 0, Key.Enter) { RoutedEvent = DataGrid.PreviewKeyDownEvent});
        mock.DataGridInstance.CurrentCell.Column.DisplayIndex.Should().Be(1);
        ((DataGridRow)mock.DataGridInstance.ItemContainerGenerator.ContainerFromIndex(2)).IsEditing.Should().BeTrue();


    }

}