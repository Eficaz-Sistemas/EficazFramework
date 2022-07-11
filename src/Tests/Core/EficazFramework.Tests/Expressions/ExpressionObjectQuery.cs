﻿using EficazFramework.Extensions;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Expressions;

public class ExpressionObjectQueryTests
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
        
        var translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);
        translated.First().FieldName.Should().Be(item.SelectedProperty.PropertyPath);
        translated.First().FieldName.Should().Be("ID");
        translated.First().Operator.Should().Be(item.Operator);
        translated.First().Value.Should().Be(item.Value1);
        translated.First().Value2.Should().Be(item.Value2);
        translated.First().CollectionName.Should().Be(item.SelectedProperty.CollectionName);
        translated.First().ConversionTargetType.Should().Be(item.ConversionTargetType);

        item.Value1 = "non-number-test";
        item.Value1.Should().BeNull();
        item.Value2 = "non-number-test";
        item.Value2.Should().BeNull();
        translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);
        translated.First().Value.Should().BeNull();
        translated.First().Value2.Should().BeNull();

        item.Value1 = 4;
        item.Value2 = 9;
        translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);
        translated.First().Value.Should().Be(4);
        translated.First().Value2.Should().Be(9);


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

        var translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);
        translated.First().FieldName.Should().Be(item.SelectedProperty.PropertyPath);
        translated.First().FieldName.Should().Be("Name");
        translated.First().Operator.Should().Be(Enums.CompareMethod.Contains);
        translated.First().Value.Should().Be(item.Value1);
        translated.First().Value.Should().BeNull();
        translated.First().Value2.Should().Be(item.Value2);
        translated.First().Value2.Should().BeNull();
        translated.First().CollectionName.Should().Be(item.SelectedProperty.CollectionName);
        translated.First().ConversionTargetType.Should().Be(item.ConversionTargetType);
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

        var translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);
        translated.First().FieldName.Should().Be(item.SelectedProperty.PropertyPath);
        translated.First().FieldName.Should().Be("Birth");
        translated.First().Operator.Should().Be(Enums.CompareMethod.Between);
        translated.First().Value.Should().Be(item.Value1);
        translated.First().Value.Should().BeNull();
        translated.First().Value2.Should().Be(item.Value2);
        translated.First().Value2.Should().BeNull();
        translated.First().CollectionName.Should().Be(item.SelectedProperty.CollectionName);
        translated.First().ConversionTargetType.Should().Be(item.ConversionTargetType);

        item.Value1 = DateTime.Now.MonthStartDate();
        item.Value2 = DateTime.Now.MonthEndDate(false, false, true);
        translated = item.ToExpressionObjectQuery();
        translated.First().Value.Should().Be(DateTime.Now.MonthStartDate());
        translated.First().Value2.Should().Be(DateTime.Now.MonthEndDate(false, false, true));

        item.Value1 = "non-number-test";
        item.Value1.Should().BeNull();
        item.Value2 = "non-number-test";
        item.Value2.Should().BeNull();
        translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);
        translated.First().Value.Should().BeNull();
        translated.First().Value2.Should().BeNull();
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
        item.SelectedProperty = IsActiveProperty;
        item.Value1 = true;
        
        var translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);
        translated.First().FieldName.Should().Be(item.SelectedProperty.PropertyPath);
        translated.First().FieldName.Should().Be("IsActive");
        translated.First().Operator.Should().Be(Enums.CompareMethod.Equals);
        translated.First().Value.Should().Be(item.Value1);
        translated.First().Value.Should().Be(true);
        translated.First().Value2.Should().Be(item.Value2);
        translated.First().Value2.Should().BeNull();
        translated.First().CollectionName.Should().Be(item.SelectedProperty.CollectionName);
        translated.First().ConversionTargetType.Should().Be(item.ConversionTargetType);

        item.Value1 = false;
        translated = item.ToExpressionObjectQuery();
        translated.First().Value.Should().Be(item.Value1);
        translated.First().Value.Should().Be(false);
    }

    [Test]
    public void NullTests()
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
        item.SelectedProperty.Should().BeNull();

        var translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(0);

        item.SelectedProperty = TeamProperty;
        translated = item.ToExpressionObjectQuery();
        translated.Should().HaveCount(1);

        translated.First().Operator.Should().Be(Enums.CompareMethod.Different);
        translated.First().Value.Should().BeNull();

    }


    private static ExpressionBuilder DefaultInstance()
    {

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
        ExpressionProperty CreatedInProperty = new()
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
        ExpressionProperty IsActiveProperty = new()
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
            Enums.CompareMethod.Equals,
            Enums.CompareMethod.Length
        }
        };
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
        ExpressionProperty ChildIdProperty = new()
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
        ExpressionProperty RelatedProperty = new()
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

        ExpressionBuilder builder = new ExpressionBuilder();
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


    [Test]
    public void SimpleExpressionTest()
    {
        List<Validation.SampleObject> dataSource = new()
        {
            new() { ID = 1, Name = "Item 1" },
            new() { ID = 2, Name = "Item 2", Children = { new() { ParentID = 2, ID = 1, Name = "Child 1 of Item 2" }, new() { ParentID = 2, ID = 2, Name = "Child 2 of Item 2" } } },
            new() { ID = 3, Name = "Item 3", Children = { new() { ParentID = 3, ID = 1, Name = "Child 1 of Item 3" }, new() { ParentID = 3, ID = 2, Name = "Child 2 of Item 3" }, new() { ParentID = 3, ID = 3, Name = "Child 2 of Item 3" } } },
            new() { ID = 4, Name = "Item 4", Related = new() { ID = 55 }, RelatedID = 55 },
            new() { ID = 5, Name = "Item 5", Related = new() { ID = 55 }, RelatedID = 55 },
            new() { ID = 9, Name = "kkkkkKk", Related = new() { ID = 99 }, RelatedID = 99 }
        };

        ExpressionBuilder builder = DefaultInstance();
        
        // no filters
        var querySource = builder.ToExpressionObjectQuery();
        var expression = EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<Validation.SampleObject>(querySource);
        querySource.Should().HaveCount(0);
        expression.Should().BeNull();

        // simple filter: ID equals 1
        builder.Items.Add(new ExpressionItem()
        {
            SelectedProperty = builder.Properties.First(),
        });
        querySource = builder.ToExpressionObjectQuery();
        querySource.Should().HaveCount(1);
        expression = EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<Validation.SampleObject>(querySource);
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        var dataresult = dataSource.Where(expression.Compile()).ToList();
        dataresult.Should().HaveCount(1);
        dataresult.First().ID.Should().Be(1);

        // simple filter: ID bigger than 1
        builder.Items.First().Operator = Enums.CompareMethod.BiggerThan;
        querySource = builder.ToExpressionObjectQuery();
        querySource.Should().HaveCount(1);
        expression = EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<Validation.SampleObject>(querySource);
        expression.Should().NotBeNull();
        expression.ReturnType.Should().Be(typeof(bool));
        dataresult = dataSource.Where(expression.Compile()).ToList();
        dataresult.Should().HaveCount(5);
        dataresult.First().ID.Should().Be(2);
        dataresult.Where(f => f.ID == 1).ToList().Should().HaveCount(0);
    }
}
