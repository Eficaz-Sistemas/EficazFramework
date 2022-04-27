using System;
using System.Linq;
using EficazFramework.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.Validation.Fluent.Rules;

internal class Unique<T> : Rules.ValidationRule<T> where T : Entities.EntityBase
{

    /// <summary>
    /// Instância de DbSet para DbContext
    /// </summary>
    public Microsoft.EntityFrameworkCore.DbSet<T> DbContextDbSet { get; }

    /// <summary>
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    public Unique(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, Microsoft.EntityFrameworkCore.DbSet<T> dbContextDbSet) : base(propertyexpression)
    {
        DbContextDbSet = dbContextDbSet;
    }
    
    public override string Validate(T instance)
    {
        var value = Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value is null)
            return null;

        if (!instance.IsNew)
            return null;

        Expressions.ExpressionBuilder builder = new();
        Expressions.ExpressionItem exprItem = new()
        {
            SelectedProperty = new()
            {
                PropertyPath = GetPropertyName(),
                DisplayName = GetPropertyName()
            },
            Operator = Enums.CompareMethod.Equals,
            Value1 = value
        };
        builder.Items.Add(exprItem);
        var expr = builder.GetExpression<T>();
        
        if (DbContextDbSet.Count(expr) > 0)
            return String.Format(Resources.Strings.Validation.NotUnique, value);

        return null;
    }
}

/// <summary>
/// Conunto de métodos auxiliares para composição das regras de validação in-built
/// </summary>
public static partial class ValidatorUtils
{

    /// <summary>
    /// Adiciona uma regração de validação que recusa valores e/ou referências nulos ou vazios
    /// </summary>
    public static Validator<T> Unique<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, Microsoft.EntityFrameworkCore.DbSet<T> dbContextDbSet) where T : Entities.EntityBase
    {
        validator.ValidationRules.Add(new Unique<T>(propertyexpression, dbContextDbSet));
        return validator;
    }
}
