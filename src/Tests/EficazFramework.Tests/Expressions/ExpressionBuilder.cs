using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace EficazFramework.Expressions;

public class ExpressionPropertyTests
{
    [Test, Order(1)]
    public void OperatorsTest()
    {
        // default
        ExpressionProperty expressionProperty = new()
        {
            PropertyPath = "ID",
            DisplayName = "Código",
            Editor = ExpressionEditor.Number,
            DefaultOperator = Enums.CompareMethod.Between,
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
        expressionProperty.ToString().Should().Be("Código");
        var operators = expressionProperty.GetOperators();
        operators.Should().HaveCount(7);
        operators.ElementAt(0).Description.Should().Be(Resources.Strings.DataDescriptions.eComparer_LowerThan);
        operators.ElementAt(4).Description.Should().Be(Resources.Strings.DataDescriptions.eComparer_Between);

        // booleans
        ExpressionProperty boolProperty = new()
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
        operators = boolProperty.GetOperators();
        operators.Should().HaveCount(1);
        operators.ElementAt(0).Description.Should().Be(Resources.Strings.DataDescriptions.eComparer_Equals);
        var values = boolProperty.GetEnumValues();
        values.Should().HaveCount(2);
        values.ElementAt(0).Description.Should().Be(Resources.Strings.DataDescriptions.BoolToYesNo_True);
        values.ElementAt(1).Description.Should().Be(Resources.Strings.DataDescriptions.BoolToYesNo_False);

        // enums
        ExpressionProperty enumProperty = new()
        {
            PropertyPath = "Team",
            DisplayName = "Time",
            Editor = ExpressionEditor.EnumSelection,
            EnumType = typeof(Team),
            DefaultOperator = Enums.CompareMethod.Equals,
            Operators = new()
            {
                Enums.CompareMethod.Different,
                Enums.CompareMethod.Equals
            }
        };
        operators = enumProperty.GetOperators();
        operators.Should().HaveCount(2);
        operators.ElementAt(0).Description.Should().Be(Resources.Strings.DataDescriptions.eComparer_Different);
        operators.ElementAt(1).Description.Should().Be(Resources.Strings.DataDescriptions.eComparer_Equals);
        values = enumProperty.GetEnumValues();
        values.Should().HaveCount(3);
        values.ElementAt(0).Description.Should().Be("EnumTeamA");
        values.ElementAt(1).Description.Should().Be("EnumTeamB");
        values.ElementAt(2).Description.Should().Be("EnumTeamC");

        // localized enum descriptions
        ExpressionProperty localizedEnumProperty = new()
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
        values = localizedEnumProperty.GetEnumValues();
        values.Should().HaveCount(3);
        values.ElementAt(0).Description.Should().Be("Time A");
        values.ElementAt(1).Description.Should().Be("Time B");
        values.ElementAt(2).Description.Should().Be("Time C");
    }
}

internal enum Team
{
    [EficazFramework.Attributes.DisplayName("EnumTeamA", ResourceType = typeof(Resources.Strings.TestStrings))]
    TeamA,
    [EficazFramework.Attributes.DisplayName("EnumTeamB", ResourceType = typeof(Resources.Strings.TestStrings))]
    TeamB,
    [EficazFramework.Attributes.DisplayName("EnumTeamC", ResourceType = typeof(Resources.Strings.TestStrings))]
    TeamC
}