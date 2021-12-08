using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using EficazFramework.Extensions;

namespace EficazFramework.Expressions;

public class ExpressionItemTests
{
    [Test]
    public void NumberTest()
    {
        // property
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

        // model
        ExpressionItem item = new();

        // number (int)
        item.SelectedProperty = IdProperty;
        item.SelectedPropertyPath.Should().Be("ID");
        item.Operator.Should().Be(Enums.CompareMethod.Equals);
        item.AvailableOperators.Should().HaveCount(7);
        item.Value1.Should().Be(1);
        item.ValueToString.Should().Be("1");
        item.Value2.Should().Be(5);
        item.ValueToString.Should().Be("1");
        item.Value1 = "non-number-test";
        item.Value1.Should().BeNull();
        item.Value2 = "non-number-test";
        item.Value2.Should().BeNull();
        item.Value1 = 4;
        item.Value1.Should().Be(4);
        item.Value2 = 9;
        item.Value2.Should().Be(9);

        item.ToString().Should().Be("Código Igual a 4");
        item.Operator = Enums.CompareMethod.Between;
        item.ToString().Should().Be("Código Entre 4 - 9");
    }

    [Test]
    public void TextTest()
    {
        // property
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

        // model
        ExpressionItem item = new();

        // text (string)
        item.SelectedProperty = NameProperty;
        item.SelectedPropertyPath.Should().Be("Name");
        item.Operator.Should().Be(Enums.CompareMethod.Contains);
        item.AvailableOperators.Should().HaveCount(4);
        item.Value1.Should().Be(null);
        item.ValueToString.Should().Be(null);
    }

    [Test]
    public void DateTimeTest()
    {
        // property
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

        // model
        ExpressionItem item = new();

        // date
        item.SelectedProperty = BirthProperty;
        item.SelectedPropertyPath.Should().Be("Birth");
        item.Operator.Should().Be(Enums.CompareMethod.Between);
        item.AvailableOperators.Should().HaveCount(7);
        item.Value1.Should().Be(null);
        item.Value2.Should().Be(null);
        item.ValueToString.Should().Be(null);
        item.Value1StringFormat = "dd/MM/yyyy";
        item.Value2StringFormat = "dd/MM/yyyy";
        item.Value1 = DateTime.Now.MonthStartDate();
        item.Value2 = DateTime.Now.MonthEndDate(false, false, true);
        item.ValueToString.Should().Be($"{DateTime.Now.MonthStartDate():dd/MM/yyyy} - {DateTime.Now.MonthEndDate(false, false, true):dd/MM/yyyy}");
        item.Value1 = "non-number-test";
        item.Value1.Should().BeNull();
        item.Value2 = "non-number-test";
        item.Value2.Should().BeNull();
        item.Value1 = DateTime.Now.MonthStartDate();
        item.Value1.Should().NotBeNull();
        item.Value2 = DateTime.Now.MonthEndDate(false, false, true);
        item.Value2.Should().NotBeNull();
    }

    [Test]
    public void BoolTest()
    {
        // property
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

        // model
        ExpressionItem item = new();

        // bool
        item.Value1StringFormat = null;
        item.Value2StringFormat = null;
        item.SelectedProperty = IsActiveProperty;
        item.SelectedPropertyPath.Should().Be("IsActive");
        item.Operator.Should().Be(Enums.CompareMethod.Equals);
        item.AvailableOperators.Should().HaveCount(1);
        item.EnumValues.Should().HaveCount(2);
        item.EnumValues.ElementAt(0).Value.Should().Be(true);
        item.EnumValues.ElementAt(0).Description.Should().Be(Resources.Strings.DataDescriptions.BoolToYesNo_True);
        item.EnumValues.ElementAt(1).Value.Should().Be(false);
        item.EnumValues.ElementAt(1).Description.Should().Be(Resources.Strings.DataDescriptions.BoolToYesNo_False);
        item.Value1 = true;
        item.ValueToString.Should().Be(Resources.Strings.DataDescriptions.BoolToYesNo_True);
    }

    [Test]
    public void EnumSimpleTest()
    {
        // property
        ExpressionProperty TeamProperty = new()
        {
            PropertyPath = "Team",
            DisplayName = "Time",
            Editor = ExpressionEditor.EnumSelection,
            EnumType = typeof(Team),
            DefaultOperator = Enums.CompareMethod.Different,
            Operators = new()
            {
                Enums.CompareMethod.Different,
                Enums.CompareMethod.Equals
            }
        };

        // model
        ExpressionItem item = new();

        // enum (basic)
        item.SelectedProperty = TeamProperty;
        item.SelectedPropertyPath.Should().Be("Team");
        item.Operator.Should().Be(Enums.CompareMethod.Different);
        item.AvailableOperators.Should().HaveCount(2);
        item.EnumValues.Should().HaveCount(3);
        item.EnumValues.ElementAt(0).Value.Should().Be(Team.TeamA);
        item.EnumValues.ElementAt(0).Description.Should().Be("EnumTeamA");
        item.EnumValues.ElementAt(1).Value.Should().Be(Team.TeamB);
        item.EnumValues.ElementAt(1).Description.Should().Be("EnumTeamB");
        item.EnumValues.ElementAt(2).Value.Should().Be(Team.TeamC);
        item.EnumValues.ElementAt(2).Description.Should().Be("EnumTeamC");
        item.Value1 = Team.TeamB;
        item.ValueToString.Should().Be("EnumTeamB");
    }

    [Test]
    public void EnumLocalizationTest()
    {
        // property
        ExpressionProperty TeamLocalizedProperty = new()
        {
            PropertyPath = "Team",
            DisplayName = "Time",
            Editor = ExpressionEditor.EnumLocalizedSelection,
            EnumType = typeof(Team),
            DefaultOperator = Enums.CompareMethod.Different,
            Operators = new()
            {
                Enums.CompareMethod.Different,
                Enums.CompareMethod.Equals
            }
        };

        // model
        ExpressionItem item = new();

        // enum (localized)
        item.SelectedProperty = TeamLocalizedProperty;
        item.SelectedPropertyPath.Should().Be("Team");
        item.Operator.Should().Be(Enums.CompareMethod.Different);
        item.AvailableOperators.Should().HaveCount(2);
        item.EnumValues.Should().HaveCount(3);
        item.EnumValues.ElementAt(0).Value.Should().Be(Team.TeamA);
        item.EnumValues.ElementAt(0).Description.Should().Be(Resources.Strings.TestStrings.EnumTeamA);
        item.EnumValues.ElementAt(1).Value.Should().Be(Team.TeamB);
        item.EnumValues.ElementAt(1).Description.Should().Be(Resources.Strings.TestStrings.EnumTeamB);
        item.EnumValues.ElementAt(2).Value.Should().Be(Team.TeamC);
        item.EnumValues.ElementAt(2).Description.Should().Be(Resources.Strings.TestStrings.EnumTeamC);
        item.Value1 = Team.TeamB;
        item.ValueToString.Should().Be(Resources.Strings.TestStrings.EnumTeamB);
    }

    [Test]
    public void DecimalNumberTest()
    {
        // property
        ExpressionProperty SalaryProperty = new()
        {
            PropertyPath = "Salary",
            DisplayName = "Salário",
            Editor = ExpressionEditor.Number,
            DecimalPlaces = 2,
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

        // number (decimal)
        item.Value1StringFormat = "n2";
        item.Value2StringFormat = "n2";
        item.SelectedProperty = SalaryProperty;
        item.SelectedPropertyPath.Should().Be("Salary");
        item.Operator.Should().Be(Enums.CompareMethod.Between);
        item.AvailableOperators.Should().HaveCount(7);
        item.Value1.Should().Be(null);
        item.Value2.Should().Be(null);
        item.ValueToString.Should().Be(null);
        item.Value1 = 1500.5678M;
        item.ValueToString.Should().Be(null);
        item.Value2 = 900.362M;
        item.ValueToString.Should().Be("1.500,57 - 900,36");
    }

    [Test]
    public void ValidationTest()
    {
        // property
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

        // model
        ExpressionItem item = new();
        bool ignored = false;
        ExpressionBuilder expressionBuilder = new(); // requires for component level's AllowNull check
        expressionBuilder.Items.Add(item);
        expressionBuilder.AllowNulls = true;

        // empty validation
        var result = item.Validate(ref ignored);
        result.Should().BeNull();


        // null not allowed
        IdProperty.AllowNull = false;
        item.SelectedProperty = IdProperty;
        result = item.Validate(ref ignored);
        result.Should().BeNull();

        item.Value1 = null;
        result = item.Validate(ref ignored);
        result.Should().NotBeNull();

        item.Value2 = null;
        result = item.Validate(ref ignored);
        result.Should().NotBeNull();

        item.Value1 = 1;
        result = item.Validate(ref ignored);
        result.Should().BeNull();

        item.Operator = Enums.CompareMethod.Between;
        result = item.Validate(ref ignored);
        result.Should().NotBeNull();

        item.Value2 = 2;
        result = item.Validate(ref ignored);
        result.Should().BeNull();


        // null allowed
        IdProperty.AllowNull = true;
        item.Value1 = null;
        item.Value2 = null;
        result = item.Validate(ref ignored);
        result.Should().BeNull();

        item.Operator = Enums.CompareMethod.Equals;
        result = item.Validate(ref ignored);
        result.Should().BeNull();

        item.Value1 = 3;
        item.Value2 = 4;
        result = item.Validate(ref ignored);
        result.Should().BeNull();

    }
}
