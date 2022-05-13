using EficazFramework.Extensions;
using System;
using System.Globalization;

namespace EficazFramework.Validation.Fluent.Rules;

internal class RangePeriod<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Define se o valor final pode ser igual ao valor inicial.
    /// </summary>
    public bool AllowEquals { get; set; } = true;

    /// <summary>
    /// Formato de data ou número para exibição na mensagem
    /// </summary>
    public string ValuesStringFormatForMessage { get; set; } = "{0}";

    public string DateTimMessagePattern { get; set; } = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

    /// <summary>
    /// Expressão lambda para acesso à propriedade contendo o valor inicial que deve ser validado
    /// </summary>
    public System.Linq.Expressions.Expression<Func<T, object>> StartProperty { get; private set; }

    /// <summary>
    /// Expressão lambda para acesso à propriedade contendo o valor final que deve ser validado
    /// </summary>
    public System.Linq.Expressions.Expression<Func<T, object>> EndProperty => Property;

    /// <summary>
    /// Obtém o nome da propriedade a ser validada pela regra
    /// </summary>
    internal string GetStartPropertyName()
    {
        if (StartProperty is null)
            return null;
        return StartProperty.GetName();
    }



    /// <summary>
    /// Regra de validação que confronta dois valores de um intervalo.
    /// </summary>
    public RangePeriod(System.Linq.Expressions.Expression<Func<T, object>> endValueExpression, System.Linq.Expressions.Expression<Func<T, object>> startValueExpression, bool allowEquals = true) : base(endValueExpression)
    {
        AllowEquals = allowEquals;
        StartProperty = startValueExpression;
    }

    public override string Validate(T instance)
    {
        var value_start = StartProperty.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        var value_end = EndProperty.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)

        if (value_start == null || value_end == null) return null; //not nulls must be handled by Required validator

        try
        {
            if (AllowEquals)
            {
                if (((dynamic)value_end) < ((dynamic)value_start))
                    return string.Format(Resources.Strings.Validation.InvalidRangePeriod_Lower, GetPropertyName(), GetStartPropertyName());
            }
            else
            {
                if (((dynamic)value_end) <= ((dynamic)value_start))
                    return string.Format(Resources.Strings.Validation.InvalidRangePeriod_LowerOrEquals, GetPropertyName(), GetStartPropertyName());
            }
        }
        catch (Exception ex)
        {
            return string.Format(Resources.Strings.Validation.ValidationException, GetPropertyName(), ex.Message);
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
    /// Adiciona uma regração de validação contra uma dupla de valores dentro de um período.
    /// </summary>
    public static Validator<T> RangePeriodo<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> statrtValueExpression, System.Linq.Expressions.Expression<Func<T, object>> endValueExpression, bool allowEquals = true) where T : class
    {
        validator.ValidationRules.Add(new RangePeriod<T>(endValueExpression, statrtValueExpression, allowEquals));
        return validator;
    }
}
