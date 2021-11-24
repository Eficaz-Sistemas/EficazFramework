using System;
using EficazFramework.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.Validation.Fluent.Rules;

internal class MaxLenght<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Limite de caracteres aceito.
    /// </summary>
    public int Lenght { get; set; } = int.MaxValue;

    /// <summary>
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    public MaxLenght(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, int lenght) : base(propertyexpression)
    {
        Lenght = lenght;
    }

    public override string Validate(T instance)
    {
        var value = this.Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value == null) return null;

        if (value.ToString().Length > Lenght) return string.Format(Resources.Strings.Validation.MaxLenght, GetPropertyName(), Lenght);
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
    public static Validator<T> MaxLenght<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, int lenght) where T : class
    {
        validator.ValidationRules.Add(new MaxLenght<T>(propertyexpression, lenght));
        return validator;
    }
}
