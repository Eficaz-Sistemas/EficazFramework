
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

namespace EficazFramework.Controls;

[Apartment(System.Threading.ApartmentState.STA)]
public class ExpressionBuilderTests
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

    [Test]
    public void BasicTest()
    {
        mock.ExpressionBuilder.Header.Should().Be("Pesquisar");
        mock.ExpressionBuilder.ViewModel.Should().BeNull();
        mock.ExpressionBuilder.ViewModel = new();
        mock.ExpressionBuilder.ViewModel.Properties.Should().BeEmpty();
        mock.ExpressionBuilder.ViewModel.Items.Should().BeEmpty();

        //Visual Elements:
        win.UpdateLayout();
        mock.ApplyTemplate();

        var expander = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild<Expander>(mock);
        expander.IsExpanded.Should().Be(mock.ExpressionBuilder.IsExpanded);
        mock.ExpressionBuilder.IsExpanded = false;
        expander.IsExpanded.Should().Be(false);
        mock.ExpressionBuilder.IsExpanded = true;
        expander.IsExpanded.Should().Be(true);

        var dg = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild<DataGrid>(mock);
        dg.Should().NotBeNull();

        var btAdd = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<Button>(mock, "PART_AddCommand");
        btAdd.Should().NotBeNull();
        btAdd.Visibility.Should().Be(Visibility.Visible);
        dg.Columns[0].Visibility.Should().Be(Visibility.Visible);

        mock.ExpressionBuilder.ViewModel.CanAddExpressions = false;
        dg.Columns[0].Visibility.Should().Be(Visibility.Collapsed);
        btAdd.Visibility.Should().Be(Visibility.Collapsed);

        btAdd.Command.Execute(null);
        mock.ExpressionBuilder.ViewModel.Items.Should().BeEmpty();
        mock.ExpressionBuilder.ViewModel.CanAddExpressions = true;
        dg.Columns[0].Visibility.Should().Be(Visibility.Visible);
        btAdd.Visibility.Should().Be(Visibility.Visible);
        btAdd.Command.Execute(null);
        mock.ExpressionBuilder.ViewModel.Items.Should().HaveCount(1);

        dg.Columns[1].IsReadOnly.Should().BeFalse();
        dg.Columns[2].IsReadOnly.Should().BeFalse();
        mock.ExpressionBuilder.ViewModel.CanBuildCustomExpressions = false;
        dg.Columns[1].IsReadOnly.Should().BeTrue();
        dg.Columns[2].IsReadOnly.Should().BeTrue();
        mock.ExpressionBuilder.ViewModel.CanBuildCustomExpressions = true;
        dg.Columns[1].IsReadOnly.Should().BeFalse();
        dg.Columns[2].IsReadOnly.Should().BeFalse();

        DataGridCell cell = (DataGridCell)dg.GetCell(mock.ExpressionBuilder.ViewModel.Items[0], 0);
        FrameworkElement presenter = (FrameworkElement)cell.Content;
        var btRemove = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild<Button>(presenter);
        btRemove.Should().NotBeNull();
        btRemove.DataContext.Should().Be(mock.ExpressionBuilder.ViewModel.Items[0]);
        mock.ExpressionBuilder.ViewModel.Items.Should().HaveCount(1);
        btRemove.Command.Execute(btRemove.CommandParameter);
        mock.ExpressionBuilder.ViewModel.Items.Should().BeEmpty();

    }
}
