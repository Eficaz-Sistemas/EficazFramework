using EficazFramework.Extensions;
using System;

namespace EficazFramework.Validation.Fluent.Rules;

internal class Equals<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Limite de caracteres aceito.
    /// </summary>
    public System.Linq.Expressions.Expression<Func<T, object>> To { get; set; } = null;


    /// <summary>
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    public Equals(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, System.Linq.Expressions.Expression<Func<T, object>> to) : base(propertyexpression)
    {
        To = to;
    }

    public override string Validate(T instance)
    {
        var value = Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value == null) return null;

        var target_value = To.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (target_value == null) return null;


        if (!value.Equals(target_value)) return string.Format(Resources.Strings.Validation.EqualsTo, GetPropertyName(), To.GetName());
        return null;
    }
}

/// <summary>
/// Conunto de métodos auxiliares para composição das regras de validação in-built
/// </summary>
public static partial class ValidatorUtils
{

    /// <summary>
    /// Adiciona uma regração de validação que recusa textos acima do limite de caracteres.s
    /// </summary>
    public static Validator<T> Equals<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, System.Linq.Expressions.Expression<Func<T, object>> to) where T : class
    {
        validator.ValidationRules.Add(new Equals<T>(propertyexpression, to));
        return validator;
    }
}
