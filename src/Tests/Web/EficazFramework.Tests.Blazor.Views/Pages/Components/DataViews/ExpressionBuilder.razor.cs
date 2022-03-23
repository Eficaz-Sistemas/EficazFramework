using EficazFramework.Expressions;

namespace EficazFramework.Tests.Blazor.Views.Pages.Components.DataViews;

public partial class ExpressionBuilder
{
    EficazFramework.Expressions.ExpressionBuilder expressionBuilder = new();
    readonly ExpressionProperty IdProperty = new()
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
    readonly ExpressionProperty NameProperty = new()
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
    readonly ExpressionProperty CreatedInProperty = new()
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
    readonly ExpressionProperty IsActiveProperty = new()
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
    readonly ExpressionProperty TeamProperty = new()
    {
        PropertyPath = "Team",
        DisplayName = "Time",
        Editor = ExpressionEditor.EnumSelection,
        EnumType = typeof(Resources.Mocks.Team),
        DefaultOperator = Enums.CompareMethod.Different,
        Operators = new()
        {
            Enums.CompareMethod.Different,
            Enums.CompareMethod.Equals,
            Enums.CompareMethod.Length
        }
    };
    readonly ExpressionProperty TeamLocalizedProperty = new()
    {
        PropertyPath = "Team",
        DisplayName = "Time",
        Editor = ExpressionEditor.EnumLocalizedSelection,
        EnumType = typeof(Resources.Mocks.Team),
        DefaultOperator = Enums.CompareMethod.Different,
        Operators = new()
        {
            Enums.CompareMethod.Different,
            Enums.CompareMethod.Equals
        }
    };
    readonly ExpressionProperty SalaryProperty = new()
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
    readonly ExpressionProperty ChildIdProperty = new()
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
    readonly ExpressionProperty RelatedProperty = new()
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

    protected override void OnInitialized()
    {
        base.OnInitialized();
        expressionBuilder.Properties.Add(IdProperty);
        expressionBuilder.Properties.Add(NameProperty);
        expressionBuilder.Properties.Add(CreatedInProperty);
        expressionBuilder.Properties.Add(IsActiveProperty);
        expressionBuilder.Properties.Add(TeamProperty);
        expressionBuilder.Properties.Add(TeamLocalizedProperty);
        expressionBuilder.Properties.Add(SalaryProperty);
        expressionBuilder.Properties.Add(ChildIdProperty);
        expressionBuilder.Properties.Add(RelatedProperty);
    }

}
