using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using EficazFramework.XAML.Behaviors;
using System.Windows;
using System.Windows.Data;

namespace EficazFramework.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class DataGridAssist
{
    Tests.WPF.Views.Behaviors.DataGridNavigation? mock = null;

    [SetUp]
    public void Setup()
    {
        mock = new();
        Tests.TestContext.Application.MainWindow.Content = mock;
        Tests.TestContext.Application.MainWindow.Show();
    }

    [Test, Order(1)]
    public void NavigationTemplateTest()
    {

        EficazFramework.XAML.Behaviors.DataGridAssist.GetEnterKeyNavigation(mock.DataGridInstance).Should().BeTrue();
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

        //disabling Enter Key Navigation
        EficazFramework.XAML.Behaviors.DataGridAssist.SetEnterKeyNavigation(mock.DataGridInstance, false);
        mock.DataGridInstance.SelectAndFocusCell(0, mock.ItemsSource.Single(e => e.Name == "Blog 5"));
        mock.DataGridInstance.IsKeyboardFocusWithin.Should().BeTrue();

        mock.ItemsSource.IndexOf((Resources.Mocks.Classes.Blog)mock.DataGridInstance.CurrentCell.Item).Should().Be(5);
        mock.DataGridInstance.CurrentCell.Item.Should().Be(mock.ItemsSource[5]);
        mock.DataGridInstance.CurrentCell.Column.DisplayIndex.Should().Be(0);
        ((DataGridRow)mock.DataGridInstance.ItemContainerGenerator.ContainerFromIndex(5)).IsEditing.Should().BeTrue();

        focused = Keyboard.FocusedElement;
        mock.DataGridInstance.RaiseEvent(new System.Windows.Input.KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual((System.Windows.Media.Visual)focused), 0, Key.Enter) { RoutedEvent = DataGrid.PreviewKeyDownEvent });
        // default Datagrid behavior: just commit the editing cell when pressing enter
        mock.DataGridInstance.CurrentCell.Item.Should().Be(mock.ItemsSource[5]);
        mock.DataGridInstance.CurrentCell.Column.DisplayIndex.Should().Be(0);
        ((DataGridRow)mock.DataGridInstance.ItemContainerGenerator.ContainerFromIndex(2)).IsEditing.Should().BeFalse();
    }

    [Test, Order(2)]
    public void NavigationTemplateWithGroupingTest()
    {
        mock?.DataGridInstance.Items.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
        mock?.UpdateLayout();

        EficazFramework.XAML.Behaviors.DataGridAssist.GetEnterKeyNavigation(mock.DataGridInstance).Should().BeTrue();
        mock.DataGridInstance.Items.Count.Should().Be(mock.DataGridInstance.Items.Count);

        mock.DataGridInstance.SelectAndFocusCell(0, mock.ItemsSource.Single(e => e.Name == "Blog 2"));
        mock.DataGridInstance.IsKeyboardFocusWithin.Should().BeTrue();

        mock.ItemsSource.IndexOf((Resources.Mocks.Classes.Blog)mock.DataGridInstance.CurrentCell.Item).Should().Be(2);
        mock.DataGridInstance.CurrentCell.Item.Should().Be(mock.ItemsSource[2]);
        mock.DataGridInstance.CurrentCell.Column.DisplayIndex.Should().Be(0);
        var input = ((DataGridRow)mock.DataGridInstance.ItemContainerGenerator.ContainerFromItem(mock.ItemsSource[2])); //.IsEditing.Should().BeTrue();
        input.IsEditing.Should().BeTrue();

        //move to next column
        var focused = Keyboard.FocusedElement;
        mock.DataGridInstance.RaiseEvent(new System.Windows.Input.KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual((System.Windows.Media.Visual)focused), 0, Key.Enter) { RoutedEvent = DataGrid.PreviewKeyDownEvent });
        mock.DataGridInstance.CurrentCell.Column.DisplayIndex.Should().Be(1);
        ((DataGridRow)mock.DataGridInstance.ItemContainerGenerator.ContainerFromItem(mock.ItemsSource[2])).IsEditing.Should().BeTrue();
    }

    [Test, Order(3)]
    public void GetRowAndCellTest()
    {

        mock.DataGridInstance.SelectAndFocusCell(0, mock.ItemsSource.Single(e => e.Name == "Blog 1"));
        mock.DataGridInstance.IsKeyboardFocusWithin.Should().BeTrue();
        mock.DataGridInstance.CommitEdit().Should().BeTrue();

        DataGridRow row = (DataGridRow)mock.DataGridInstance.GetRow(mock.ItemsSource[45]);
        mock.DataGridInstance.SelectAndFocusCell(0, row);
        mock.DataGridInstance.CurrentCell.Item.Should().Be(mock.ItemsSource[45]);
        mock.DataGridInstance.IsKeyboardFocusWithin.Should().BeTrue();
        mock.DataGridInstance.CommitEdit().Should().BeTrue();


        DataGridCell cell = (DataGridCell)mock.DataGridInstance.GetCell(row, 0);
        cell.DataContext.Should().Be(mock.ItemsSource[45]);

        DataGridCell cell2 = (DataGridCell)mock.DataGridInstance.GetCell(mock.ItemsSource[45], 0);
        cell2.DataContext.Should().Be(mock.ItemsSource[45]);
    }

    [Test, Order(5)]
    public void ColumnFilterTest()
    {

    }
}