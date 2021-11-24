using System;
using EficazFramework.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.Validation.Fluent.Rules;

internal class Required<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Obtém ou define se a constante String.Empty será permitida ou não
    /// </summary>
    public bool AllowEmpty { get; set; } = false;

    /// <summary>
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    public Required(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, bool allowempty = false) : base(propertyexpression)
    {
        AllowEmpty = allowempty;
    }

    public override string Validate(T instance)
    {
        var value = this.Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value is null)
        {
            return string.Format(Resources.Strings.Validation.Required, this.GetPropertyName());
        }
        else if (string.IsNullOrEmpty(value.ToString()) & AllowEmpty == false)
            return string.Format(Resources.Strings.Validation.Required, this.GetPropertyName());

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
    public static Validator<T> Required<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, bool allowEmpty = false) where T : class
    {
        validator.ValidationRules.Add(new Required<T>(propertyexpression, allowEmpty));
        return validator;
    }
}
