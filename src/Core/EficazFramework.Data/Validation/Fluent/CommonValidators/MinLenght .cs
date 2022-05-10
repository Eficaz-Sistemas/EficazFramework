using EficazFramework.Extensions;
using System;

namespace EficazFramework.Validation.Fluent.Rules;

internal class MinLenght<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Limite de caracteres aceito.
    /// </summary>
    public int Lenght { get; set; }

    /// <summary>
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    public MinLenght(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, int lenght) : base(propertyexpression)
    {
        Lenght = lenght;
    }

    public override string Validate(T instance)
    {
        var value = Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value == null) return null;

        if (value.ToString().Length < Lenght) return string.Format(Resources.Strings.Validation.MinLenght, GetPropertyName(), Lenght);
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
    public static Validator<T> MinLenght<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression, int lenght) where T : class
    {
        validator.ValidationRules.Add(new MinLenght<T>(propertyexpression, lenght));
        return validator;
    }
}
