using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace EficazFramework.Expressions;

public class ExpressionItemTests
{
    [Test, Order(1)]
    public void Mvvm()
    {
        // available properties:
        ExpressionProperty IdProperty = new()
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
        ExpressionProperty NameProperty = new()
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
        ExpressionProperty BirthProperty = new()
        {
            PropertyPath = "Birth",
            DisplayName = "Aniversário",
            Editor = ExpressionEditor.Date,
            DefaultOperator = Enums.CompareMethod.Between,
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
        ExpressionProperty IsActiveProperty = new()
        {
            PropertyPath = "IsActive",
            DisplayName = "Código",
            Editor = ExpressionEditor.BoolSelection,
            DefaultOperator = Enums.CompareMethod.Equals,
            Operators = new()
            {
                Enums.CompareMethod.Equals
            }
        };
        ExpressionProperty TeamProperty = new()
        {
            PropertyPath = "Team",
            DisplayName = "Time",
            Editor = ExpressionEditor.EnumLocalizedSelection,
            EnumType = typeof(Team),
            DefaultOperator = Enums.CompareMethod.Equals,
            Operators = new()
            {
                Enums.CompareMethod.Different,
                Enums.CompareMethod.Equals
            }
        };
        ExpressionProperty SalaryProperty = new()
        {
            PropertyPath = "Salary",
            DisplayName = "Salário",
            Editor = ExpressionEditor.Number,
            DefaultOperator = Enums.CompareMethod.Between,
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

        // model
        ExpressionItem item = new();

        // number (int)
        item.SelectedProperty = IdProperty;
        item.SelectedPropertyPath.Should().Be("ID");
        item.Operator.Should().Be(Enums.CompareMethod.Equals);
        item.AvailableOperators.Should().HaveCount(7);
        item.Value1.Should().Be(1);
        item.ValueToString.Should().Be("1");

        // text (string)
        item.SelectedProperty = NameProperty;
        item.SelectedPropertyPath.Should().Be("Name");
        item.Operator.Should().Be(Enums.CompareMethod.Contains);
        item.AvailableOperators.Should().HaveCount(4);
        item.Value1.Should().Be(null);
        item.ValueToString.Should().Be(null);

        // date
        item.SelectedProperty = BirthProperty;
        item.SelectedPropertyPath.Should().Be("Birth");
        item.Operator.Should().Be(Enums.CompareMethod.Between);
        item.AvailableOperators.Should().HaveCount(7);
        item.Value1.Should().Be(null);
        item.ValueToString.Should().Be(null);

    }
}
