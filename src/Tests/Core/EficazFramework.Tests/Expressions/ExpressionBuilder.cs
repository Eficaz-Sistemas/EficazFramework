using AwesomeAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
    static readonly ExpressionProperty CreatedInProperty = new()
    {
        PropertyPath = "CreatedIn",
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
        DefaultValue1 = true,
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
            Enums.CompareMethod.Equals,
            Enums.CompareMethod.Length
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
    static readonly ExpressionProperty ChildIdProperty = new()
    {
        PropertyPath = "ID",
        DisplayName = "(Filho) Código",
        Editor = ExpressionEditor.Number,
        DefaultOperator = Enums.CompareMethod.Equals,
        DefaultValue1 = 2,
        DefaultValue2 = 5,
        CollectionName = "Children",
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


    private static ExpressionBuilder DefaultInstance()
    {
        ExpressionBuilder builder = new();
        builder.Properties.Add(IdProperty);
        builder.Properties.Add(NameProperty);
        builder.Properties.Add(CreatedInProperty);
        builder.Properties.Add(IsActiveProperty);
        builder.Properties.Add(TeamProperty);
        builder.Properties.Add(TeamLocalizedProperty);
        builder.Properties.Add(SalaryProperty);
        builder.Properties.Add(ChildIdProperty);
        builder.Properties.Add(RelatedProperty);
        RelatedProperty.FindableRelationships.Add(new() { PrincipalKey = "ID", ForeignKey = "RelatedID" });
        return builder;
    }

    [Test, Order(1)]
    public void CollectionTest()
    {
        ExpressionBuilder builder = DefaultInstance();
        builder.Items.Should().HaveCount(0);
        builder.Properties.Should().HaveCount(9);

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

        builder.CanAddExpressions = false;
        builder.DeleteItemCommand.Execute(null);
        builder.Items.Should().HaveCount(1);

        builder.CanAddExpressions = true;
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

    [Test, Order(4)]
    public void ExpressionBuildTest()
    {
        List<Validation.SampleObject> source = new()
        {
            new() { ID = 1, Name = "Item 1" },
            new() { ID = 2, Name = "Item 2", Children = { new() { ParentID = 2, ID = 1, Name = "Child 1 of Item 2" }, new() { ParentID = 2, ID = 2, Name = "Child 2 of Item 2" } } },
            new() { ID = 3, Name = "Item 3", Children = { new() { ParentID = 3, ID = 1, Name = "Child 1 of Item 3" }, new() { ParentID = 3, ID = 2, Name = "Child 2 of Item 3" }, new() { ParentID = 3, ID = 3, Name = "Child 2 of Item 3" } } },
            new() { ID = 4, Name = "Item 4", Related = new() { ID = 55 }, RelatedID = 55 },
            new() { ID = 5, Name = "Item 5", Related = new() { ID = 55 }, RelatedID = 55 },
            new() { ID = 9, Name = "kkkkkKk", Related = new() { ID = 99 }, RelatedID = 99 }
        };
        ExpressionBuilder builder = DefaultInstance();

        // null items
        var expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().BeNull();

        // numbers, dates: 
        builder.AddNewItemCommand.Execute(null);
        builder.Items[0].SelectedProperty = builder.Properties[0];
        builder.Items[0].SelectedProperty.DisplayName.Should().Be("Código");
        builder.Items[0].Operator.Should().Be(Enums.CompareMethod.Equals);
        builder.Items[0].Value1.Should().Be(1);

        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(1);

        builder.Items[0].Operator = Enums.CompareMethod.BiggerThan;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(5);

        builder.Items[0].Operator = Enums.CompareMethod.BiggerOrEqualThan;
        builder.Items[0].Value1 = 3;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(4);

        builder.Items[0].Operator = Enums.CompareMethod.LowerOrEqualThan;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(3);

        builder.Items[0].Operator = Enums.CompareMethod.LowerThan;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(2);

        builder.Items[0].Operator = Enums.CompareMethod.Between;
        builder.Items[0].Value1 = 2;
        builder.Items[0].Value2 = 4;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(3);

        builder.Items[0].Operator = Enums.CompareMethod.Different;
        builder.Items[0].Value1 = 5;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(5);

        // texts
        builder.Items[0].SelectedProperty = builder.Properties[1];
        builder.Items[0].Operator = Enums.CompareMethod.Equals;
        builder.Items[0].Value1 = "Item 2";
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(1);

        builder.Items[0].Operator = Enums.CompareMethod.Equals;
        builder.Items[0].Value1 = "Item";
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(0);

        builder.Items[0].Operator = Enums.CompareMethod.Contains;
        builder.Items[0].Value1 = "tem";
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(5);

        builder.Items[0].Value1 = "kk";
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(1);

        builder.Items[0].Operator = Enums.CompareMethod.StartsWith;
        builder.Items[0].Value1 = "It";
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(5);

        builder.Items[0].Value1 = "kk";
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(1);

        builder.Items[0].Operator = Enums.CompareMethod.Length;
        builder.Items[0].Value1 = 6;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(5);

        builder.Items[0].Value1 = 7;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(1);


        // DateTime (and Coercion)
        builder.AddNewItemCommand.Execute(null);
        builder.Items[1].SelectedProperty = builder.Properties[2];
        builder.Items[1].DateTimeValue1 = new DateTime(2021, 06, 01);
        builder.Items[1].DateTimeValue2 = new DateTime(2021, 06, 30);
        builder.Items[1].Value1.Should().Be(new DateTime(2021, 06, 01));
        builder.Items[1].Value2.Should().Be(new DateTime(2021, 06, 30, 23, 59, 59));
        builder.Items[1].DateTimeValue1.Should().Be((DateTime?)builder.Items[1].Value1);
        builder.Items[1].DateTimeValue2.Should().Be((DateTime?)builder.Items[1].Value2);
        builder.Items[1].DateTimeValue2 = new DateTime(2021, 06, 30);
        builder.Items[1].SelectedProperty = null;
        builder.Items[1].Value1.Should().BeNull();
        builder.Items[1].Value2.Should().BeNull();
        builder.Items[1].AvailableOperators.Should().BeNull();
        builder.Items.Remove(builder.Items[1]);

        // FixedItems
        builder.FixedItems.Add(new() { SelectedProperty = builder.Properties[3] });
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(0);

        source.Last().IsActive = true;
        source.Where(expression.Compile()).ToList().Should().HaveCount(1);
        builder.FixedItems.Clear();

        // Collections
        builder.Items[0].SelectedProperty = builder.Properties[7];
        builder.Items[0].SelectedProperty.DisplayName.Should().Be("(Filho) Código");
        builder.Items[0].Operator.Should().Be(Enums.CompareMethod.Equals);
        builder.Items[0].Value1.Should().Be(2);

        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(2);

        builder.Items[0].Operator = Enums.CompareMethod.BiggerThan;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(1);

        // Related Entities
        builder.Items[0].SelectedProperty = builder.Properties[8];
        builder.Items[0].SelectedProperty.DisplayName.Should().Be("Relacionado");
        builder.Items[0].SelectedPropertyPath.Should().Be("Related");
        builder.Items[0].Operator.Should().Be(Enums.CompareMethod.Equals);
        builder.Items[0].Value1.Should().BeNull();
        builder.Items[0].Value1 = new Validation.SampleRelatedObject() { ID = 55 };

        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(2);

        builder.Items[0].Operator = Enums.CompareMethod.Different;
        expression = builder.GetExpression<Validation.SampleObject>();
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        source.Where(expression.Compile()).ToList().Should().HaveCount(4);

        builder.Items[0].SelectedProperty = null;
        builder.Items[0].SelectedPropertyPath.Should().BeNull();

        builder.Dispose();
    }


}