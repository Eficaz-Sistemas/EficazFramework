
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
using EficazFramework.Expressions;

namespace EficazFramework.Controls;

[Apartment(System.Threading.ApartmentState.STA)]
public class ExpressionBuilderTests
{
    System.Windows.Window win = new();
    EficazFramework.Tests.WPF.Views.Behaviors.Inputs mock = new();

    private bool _searched = false;
    //properties
    static readonly ExpressionProperty IdProperty = new()
    {
        PropertyPath = "ID",
        DisplayName = "Código",
        Editor = ExpressionEditor.Number,
        DefaultOperator = Enums.CompareMethod.Equals,
        DefaultValue1 = 1,
        DefaultValue2 = 5,
        Operators = new()
        {
            Enums.CompareMethod.LowerThan,
            Enums.CompareMethod.LowerOrEqualThan,
            Enums.CompareMethod.Different,
            Enums.CompareMethod.Equals,
            Enums.CompareMethod.Between,
            Enums.CompareMethod.BiggerOrEqualThan,
            Enums.CompareMethod.BiggerThan
        }
    };
    static readonly ExpressionProperty NameProperty = new()
    {
        PropertyPath = "Name",
        DisplayName = "Nome",
        Editor = ExpressionEditor.Text,
        DefaultOperator = Enums.CompareMethod.Contains,
        Operators = new()
        {
            Enums.CompareMethod.Different,
            Enums.CompareMethod.Equals,
            Enums.CompareMethod.Contains,
            Enums.CompareMethod.StartsWith,
        }
    };
    static readonly ExpressionProperty RelatedProperty = new()
    {
        PropertyPath = "Related",
        DisplayName = "Relacionado",
        Editor = ExpressionEditor.Findable,
        DefaultOperator = Enums.CompareMethod.Equals,
        Operators = new()
        {
            Enums.CompareMethod.Different,
            Enums.CompareMethod.Equals
        },
    };
    private static Expressions.ExpressionBuilder DefaultViewModelInstance()
    {
        Expressions.ExpressionBuilder builder = new();
        builder.Properties.Add(IdProperty);
        builder.Properties.Add(NameProperty);
        builder.Properties.Add(RelatedProperty);
        RelatedProperty.FindableRelationships.Add(new() { PrincipalKey = "ID", ForeignKey = "RelatedID" });
        return builder;
    }


    [SetUp]
    public void Setup()
    {
        _searched = false;
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
        mock.ExpressionBuilder.Header = EficazFramework.Resources.Strings.Commands.New;
        mock.ExpressionBuilder.Header.Should().Be("Novo");
        mock.ExpressionBuilder.ViewModel.Should().BeNull();
        mock.ExpressionBuilder.ViewModel = new();
        mock.ExpressionBuilder.ViewModel.Properties.Should().BeEmpty();
        mock.ExpressionBuilder.ViewModel.Items.Should().BeEmpty();

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

    [Test]
    public void SearchTest()
    {
        mock.ExpressionBuilder.SearchCommand.Should().BeNull();
        mock.ExpressionBuilder.ViewModel = DefaultViewModelInstance();
        Action search = () => mock.ExpressionBuilder.SearchCommand.Execute(null);

        search.Should().Throw<NullReferenceException>();
        mock.ExpressionBuilder.SearchCommand = new Commands.CommandBase(Search_Executed);
        search.Should().NotThrow<Exception>();
        _searched.Should().BeTrue();

        _searched = false;
        var brSearch = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<Button>(mock.ExpressionBuilder, "PART_ButtonFind");
    }

    [Test]
    public void FindablePropertyTest()
    {
        mock.ExpressionBuilder.ViewModel = DefaultViewModelInstance();
        mock.ExpressionBuilder.FindAction.Should().BeNull();

        Action findRelated = () => mock.ExpressionBuilder.FindAction.Invoke(mock.ExpressionBuilder, new(""));
        findRelated.Should().Throw<NullReferenceException>();
        mock.ExpressionBuilder.FindAction = (s, e) => _searched = true;

        mock.ExpressionBuilder.ViewModel.AddNewItemCommand.Execute(null);
        ExpressionItem propItem = mock.ExpressionBuilder.ViewModel.Items[0];
        propItem.Should().NotBeNull();
        propItem.SelectedProperty = RelatedProperty;

        DataGrid dg = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild<DataGrid>(mock.ExpressionBuilder);
        dg.Should().NotBeNull();
        dg.ItemsSource.Should().Be(mock.ExpressionBuilder.ViewModel.Items);
        dg.Items.Count.Should().Be(1);
        dg.Items.MoveCurrentToFirst();

        DataGridRow row = (DataGridRow)dg.GetRow(dg.SelectedItem);
        DataGridCell cell = (DataGridCell)dg.GetCell(row, 3);
        cell.DataContext.Should().Be(mock.ExpressionBuilder.ViewModel.Items.First());
        dg.SelectAndFocusCell(cell);
        var input = cell.Content as AutoComplete;
        input.Should().NotBeNull();

        _searched = false;
        input?.FindAction.Should().NotBeNull();
        input?.FindAction.Invoke(null, null);
        _searched.Should().BeTrue();
    }

    private void Search_Executed(object sender, Events.ExecuteEventArgs e)
    {
        _searched.Should().BeFalse();
        _searched = true;
    }
}
