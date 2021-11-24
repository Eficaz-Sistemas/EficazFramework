using EficazFramework.Extensions;
using System;

namespace EficazFramework.Validation.Fluent.Rules;

internal class Test<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Regra de validação de teste. Sempre retorna uma mensagem como erro
    /// </summary>
    public Test(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression)
    {
    }

    public override string Validate(T instance)
    {
        var value = this.Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        return string.Format("Test done. Property Name: {0}. Value: {1}", GetPropertyName(), value);
    }
}

/// <summary>
/// Conunto de métodos auxiliares para composição das regras de validação in-built
/// </summary>
public static partial class ValidatorUtils
{

    /// <summary>
    /// Adiciona uma validação de teste.
    /// </summary>
    public static Fluent.Validator<T> Test<T>(this Fluent.Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) where T : class
    {
        validator.ValidationRules.Add(new Test<T>(propertyexpression));
        return validator;
    }
}
