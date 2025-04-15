using EficazFramework.Extensions;
using System;

namespace EficazFramework.Validation.Fluent.Rules;

internal class Required<T> : Rules.ValidationRule<T> where T : class
{

    public string? DisplayName { get; set; }

    /// <summary>
    /// Obtém ou define se a constante String.Empty será permitida ou não
    /// </summary>
    public bool AllowEmpty { get; set; } = false;

    /// <summary>
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    public Required(
        System.Linq.Expressions.Expression<Func<T, object>> propertyexpression,
        string displayName = null,
        bool allowempty = false) : base(propertyexpression)
    {
        DisplayName = displayName;
        AllowEmpty = allowempty;
    }

    public override string Validate(T instance)
    {
        var value = Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value is null)
        {
            return string.Format(Resources.Strings.Validation.Required, DisplayName ?? GetPropertyName());
        }
        else if (string.IsNullOrEmpty(value.ToString()) & AllowEmpty == false)
            return string.Format(Resources.Strings.Validation.Required, DisplayName ?? GetPropertyName());

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
    public static Validator<T> Required<T>(
        this Validator<T> validator, 
        System.Linq.Expressions.Expression<Func<T, object>> propertyexpression,
        string displayName = null,
        bool allowEmpty = false) where T : class
    {
        validator.ValidationRules.Add(new Required<T>(propertyexpression, displayName, allowEmpty));
        return validator;
    }
}
