using System;
using System.Globalization;
using EficazFramework.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.Validation.Fluent.Rules;

internal class Range<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Valor numérico mínimo aceito na validação
    /// </summary>
    public decimal Minimum { get; set; } = decimal.MinValue;

    /// <summary>
    /// Valor numérico máximo aceito na validação
    /// </summary>
    public decimal Maximum { get; set; } = decimal.MaxValue;

    /// <summary>
    /// Data mínima aceita na validação
    /// </summary>
    public DateTime MinimumDate { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Data máxima aceita na validação
    /// </summary>
    public DateTime MaximumDate { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Formato de data ou número para exibição na mensagem
    /// </summary>
    public string ValuesStringFormatForMessage { get; set; } = "{0}";


    public RangeMode Mode { get; } = RangeMode.Numeric;

    public string DateTimMessagePattern { get; set; } = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;



    /// <summary>
    /// Regra de validação contra valores fora do intervalo desejado.
    /// Tipo: DATETIME
    /// </summary>
    public Range(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, DateTime minimum, DateTime maximum) : base(propertyexpression)
    {
        Mode = RangeMode.Date;
        MinimumDate = minimum;
        MaximumDate = maximum;
    }

    /// <summary>
    /// Regra de validação contra valores fora do intervalo desejado.
    /// Tipo: int16
    /// </summary>
    public Range(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, short minimum, short maximum) : base(propertyexpression)
    {
        if (minimum == short.MinValue) { Minimum = decimal.MinValue; } else { Minimum = (decimal)minimum; }
        if (maximum == short.MaxValue) { Maximum = decimal.MaxValue; } else { Maximum = (decimal)maximum; }
    }

    /// <summary>
    /// Regra de validação contra valores fora do intervalo desejado.
    /// Tipo: int32
    /// </summary>
    public Range(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, int minimum, int maximum) : base(propertyexpression)
    {
        if (minimum == int.MinValue) { Minimum = decimal.MinValue; } else { Minimum = (decimal)minimum; }
        if (maximum == int.MaxValue) { Maximum = decimal.MaxValue; } else { Maximum = (decimal)maximum; }
    }

    /// <summary>
    /// Regra de validação contra valores fora do intervalo desejado.
    /// Tipo: int64
    /// </summary>
    public Range(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, long minimum, long maximum) : base(propertyexpression)
    {
        if (minimum == long.MinValue) { Minimum = decimal.MinValue; } else { Minimum = (decimal)minimum; }
        if (maximum == long.MaxValue) { Maximum = decimal.MaxValue; } else { Maximum = (decimal)maximum; }
    }

    /// <summary>
    /// Regra de validação contra valores fora do intervalo desejado.
    /// Tipo: double
    /// </summary>
    public Range(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, double minimum, double maximum) : base(propertyexpression)
    {
        if (minimum == double.MinValue) { Minimum = decimal.MinValue; } else { Minimum = (decimal)minimum; }
        if (maximum == double.MaxValue) { Maximum = decimal.MaxValue; } else { Maximum = (decimal)maximum; }
    }

    /// <summary>
    /// Regra de validação contra valores fora do intervalo desejado.
    /// Tipo: decimal
    /// </summary>
    public Range(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, decimal minimum, decimal maximum) : base(propertyexpression)
    {
        Minimum = minimum;
        Maximum = maximum;
    }


    public override string Validate(T instance)
    {
        var value = this.Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value == null) return null; //not nulls must be handled by Required validator

        if (Mode == RangeMode.Numeric)
        {
            try
            {
                if (decimal.TryParse(value.ToString(), out decimal source))
                {
                    if (Maximum == decimal.MaxValue)
                    {
                        if (source < Minimum) return string.Format(Resources.Strings.Validation.InvalidRange_Minimum,
                                                                   GetPropertyName(),
                                                                   string.Format(ValuesStringFormatForMessage, Minimum));
                    }
                    else if (Minimum == decimal.MinValue)
                    {
                        if (source > Maximum) return string.Format(Resources.Strings.Validation.InvalidRange_Maximum,
                                                                   GetPropertyName(),
                                                                   string.Format(ValuesStringFormatForMessage, Maximum));
                    }
                    else
                    {
                        if (source < Minimum || source > Maximum) return string.Format(Resources.Strings.Validation.InvalidRange,
                                                                                       GetPropertyName(),
                                                                                       string.Format(ValuesStringFormatForMessage, Minimum),
                                                                                       string.Format(ValuesStringFormatForMessage, Maximum));
                    }
                }
            }
            catch (Exception) { }
        }
        else
        {
            try
            {
                if (value is DateTime dt)
                    if (MaximumDate == DateTime.MaxValue)
                    {
                        if (dt < MinimumDate) return string.Format(Resources.Strings.Validation.InvalidRange_Minimum,
                                                                                GetPropertyName(),
                                                                                string.Format(DateTimMessagePattern, MinimumDate));
                    }
                    else if (MinimumDate == DateTime.MinValue)
                    {
                        if (dt > MaximumDate) return string.Format(Resources.Strings.Validation.InvalidRange_Maximum,
                                                                                GetPropertyName(),
                                                                                string.Format(DateTimMessagePattern, MaximumDate));
                    }
                    else
                    {
                        if (dt < MinimumDate || dt > MaximumDate) return string.Format(Resources.Strings.Validation.InvalidRange,
                                                                                                                 GetPropertyName(),
                                                                                                                 string.Format(DateTimMessagePattern, MinimumDate),
                                                                                                                 string.Format(DateTimMessagePattern, MaximumDate));
                    }
            }
            catch (Exception) { }
        }

        return null;
    }
}

public enum RangeMode
{
    Numeric = 0,
    Date = 1
}

/// <summary>
/// Conunto de métodos auxiliares para composição das regras de validação in-built
/// </summary>
public static partial class ValidatorUtils
{

    /// <summary>
    /// Adiciona uma regração de validação contra valores fora do intervalo desejado.
    /// </summary>
    public static Validator<T> Range<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, DateTime minimum, DateTime maximum) where T : class
    {
        validator.ValidationRules.Add(new Range<T>(propertyexpression, minimum, maximum));
        return validator;
    }

    /// <summary>
    /// Adiciona uma regração de validação contra valores fora do intervalo desejado.
    /// </summary>
    public static Validator<T> Range<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, short minimum = short.MinValue, short maximum = short.MaxValue, string stringformat = "{0}") where T : class
    {
        validator.ValidationRules.Add(new Range<T>(propertyexpression, minimum, maximum) { ValuesStringFormatForMessage = stringformat });
        return validator;
    }

    /// <summary>
    /// Adiciona uma regração de validação contra valores fora do intervalo desejado.
    /// </summary>
    public static Validator<T> Range<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, int minimum = int.MinValue, int maximum = int.MaxValue, string stringformat = "{0}") where T : class
    {
        validator.ValidationRules.Add(new Range<T>(propertyexpression, minimum, maximum) { ValuesStringFormatForMessage = stringformat });
        return validator;
    }

    /// <summary>
    /// Adiciona uma regração de validação contra valores fora do intervalo desejado.
    /// </summary>
    public static Validator<T> Range<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, long minimum = long.MinValue, long maximum = long.MaxValue, string stringformat = "{0}") where T : class
    {
        validator.ValidationRules.Add(new Range<T>(propertyexpression, minimum, maximum) { ValuesStringFormatForMessage = stringformat });
        return validator;
    }

    /// <summary>
    /// Adiciona uma regração de validação contra valores fora do intervalo desejado.
    /// </summary>
    public static Validator<T> Range<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, double minimum = double.MinValue, double maximum = double.MaxValue, string stringformat = "{0}") where T : class
    {
        validator.ValidationRules.Add(new Range<T>(propertyexpression, minimum, maximum) { ValuesStringFormatForMessage = stringformat });
        return validator;
    }

    /// <summary>
    /// Adiciona uma regração de validação contra valores fora do intervalo desejado.
    /// </summary>
    public static Validator<T> Range<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, decimal minimum = decimal.MinValue, decimal maximum = decimal.MaxValue, string stringformat = "{0}") where T : class
    {
        validator.ValidationRules.Add(new Range<T>(propertyexpression, minimum, maximum) { ValuesStringFormatForMessage = stringformat });
        return validator;
    }

}
