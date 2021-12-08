using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace EficazFramework.Expressions;

public class ExpressionBuilderTests
{
    // properties
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
    static readonly ExpressionProperty BirthProperty = new()
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
    static readonly ExpressionProperty IsActiveProperty = new()
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
    static readonly ExpressionProperty TeamProperty = new()
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
    static readonly ExpressionProperty TeamLocalizedProperty = new()
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
    static readonly ExpressionProperty SalaryProperty = new()
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

    private static ExpressionBuilder DefaultInstance()
    {
        ExpressionBuilder builder = new ExpressionBuilder();
        builder.Properties.Add(IdProperty);
        builder.Properties.Add(NameProperty);
        builder.Properties.Add(BirthProperty);
        builder.Properties.Add(IsActiveProperty);
        builder.Properties.Add(TeamProperty);
        builder.Properties.Add(TeamLocalizedProperty);
        builder.Properties.Add(SalaryProperty);
        return builder;
    }

    [Test, Order(1)]
    public void CollectionTest()
    {
        ExpressionBuilder builder = DefaultInstance();
        builder.Items.Should().HaveCount(0);
        builder.Properties.Should().HaveCount(7);

        builder.AddNewItemCommand.Execute(null);
        builder.Items.Should().HaveCount(1);
        builder.CurrentItem.Should().Be(builder.Items[0]);

        builder.DeleteItemCommand.Execute(null);
        builder.Items.Should().HaveCount(0);
        builder.CurrentItem.Should().BeNull();

        builder.Items.Add(new ExpressionItem());
        builder.Items.Should().HaveCount(1);
        builder.CurrentItem.Should().Be(builder.Items[0]);

        builder.Items[0] = new ExpressionItem();
        builder.Items.Should().HaveCount(1);
        builder.CurrentItem.Should().Be(builder.Items[0]);

        builder.DeleteItemCommand.Execute(null);
        builder.Items.Should().HaveCount(0);
        builder.CurrentItem.Should().BeNull();
    }

    [Test, Order(2)]
    public void ValidationTest()
    {
        ExpressionBuilder builder = DefaultInstance();
        builder.AllowNulls = false;
        
        // ignored because there isn't any property selected
        builder.AddNewItemCommand.Execute(null);
        builder.Validate();
        builder.LastValidationErrors.Should().BeNull();
        builder.HasErrors.Should().BeFalse();

        // valid because Value1 was set to 1 by the DefaultValue1 parameter
        builder.Items[0].SelectedProperty = builder.Properties[0];
        builder.Validate();
        builder.LastValidationErrors.Should().BeNull();
        builder.HasErrors.Should().BeFalse();

        // invalid because Value1 is null now
        builder.Items[0].Value1 = null;
        builder.Validate();
        builder.LastValidationErrors.Should().NotBeNull();
        builder.HasErrors.Should().BeTrue();

        // invalid because SelectedProperty doesn't allow null, even with his parent allows
        builder.AllowNulls = true;
        builder.Validate();
        builder.LastValidationErrors.Should().NotBeNull();
        builder.HasErrors.Should().BeTrue();

        // valid because both SelectedProperty and ExpressionBuilder allow null
        builder.Items[0].SelectedProperty.AllowNull = true;
        builder.Validate();
        builder.LastValidationErrors.Should().BeNull();
        builder.HasErrors.Should().BeFalse();

        // invalid because ExpressionBuilder doesn't allow null, even with SelectedProperty allows
        builder.AllowNulls = false;
        builder.Validate();
        builder.LastValidationErrors.Should().NotBeNull();
        builder.HasErrors.Should().BeTrue();
    }

    [Test, Order(3)]
    public void CustomizationTest()
    {
        ExpressionBuilder builder = DefaultInstance();
        builder.AddNewItemCommand.Execute(null);

        builder.Items[0].SelectedProperty = builder.Properties[0];
        builder.Items[0].SelectedProperty.DisplayName.Should().Be("Código");
        builder.Items[0].Operator.Should().Be(Enums.CompareMethod.Equals);
        builder.Items[0].Value1.Should().Be(1);

        builder.Items[0].SelectedProperty = builder.Properties[1];
        builder.Items[0].SelectedProperty.DisplayName.Should().Be("Nome");
        builder.Items[0].Operator.Should().Be(Enums.CompareMethod.Contains);
        builder.Items[0].Value1.Should().Be(null);
        builder.Items[0].Value1 = "Eficaz";
        builder.Items[0].Value1.Should().Be("Eficaz");

        builder.CanBuildCustomExpressions = false;
        builder.Items[0].SelectedProperty = builder.Properties[2]; // but will be locked
        builder.Items[0].SelectedProperty.DisplayName.Should().Be("Nome"); // Aniversário, if it isn't locked
        builder.Items[0].Operator = Enums.CompareMethod.Different;
        builder.Items[0].Operator.Should().Be(Enums.CompareMethod.Contains); // Differernt, if it isn't locked
        builder.Items[0].Value1 = "Some Name";
        builder.Items[0].Value1.Should().Be("Some Name"); // lock doesn't apply heres

        builder.CanAddExpressions = false;
        builder.AddNewItemCommand.Execute(null);
        builder.Items.Should().HaveCount(1); // 2, if it isn'tt locked
        builder.Items.Add(new ExpressionItem());
        builder.Items.Should().HaveCount(2); // here it's possible to add, for internal usage.
    }


}