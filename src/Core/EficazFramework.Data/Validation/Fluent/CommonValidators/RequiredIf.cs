using EficazFramework.Extensions;
using System;

namespace EficazFramework.Validation.Fluent.Rules;

internal class RequiredIf<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Obtém ou define se a constante String.Empty será permitida ou não
    /// </summary>
    public bool AllowEmpty { get; set; } = false;

    /// <summary>
    /// Expressão que condiciona a obrigatoriedade do campo ser requerido ou não
    /// </summary>
    public System.Linq.Expressions.Expression<Func<T, bool>> ConditionExpression { get; set; } = null;


    /// <summary>
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    public RequiredIf(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression,
                      System.Linq.Expressions.Expression<Func<T, bool>> conditionExpression,
                      bool allowempty = false) : base(propertyexpression)
    {
        AllowEmpty = allowempty;
        ConditionExpression = conditionExpression;
    }

    public override string Validate(T instance)
    {
        var value = Property.Invoke(instance);
        bool shouldBeRequired = ConditionExpression?.Invoke(instance) ?? false;

        if (shouldBeRequired)
        {
            if (value is null)
            {
                return string.Format(Resources.Strings.Validation.Required, GetPropertyName());
            }
            else if (string.IsNullOrEmpty(value.ToString()) & AllowEmpty == false)
                return string.Format(Resources.Strings.Validation.Required, GetPropertyName());
        }

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
    public static Validator<T> RequiredIf<T>(this Validator<T> validator,
                                             System.Linq.Expressions.Expression<Func<T, object>> propertyexpression,
                                             System.Linq.Expressions.Expression<Func<T, bool>> conditionExpression,
                                             bool allowEmpty = false) where T : class
    {
        validator.ValidationRules.Add(new RequiredIf<T>(propertyexpression, conditionExpression, allowEmpty));
        return validator;
    }
}
