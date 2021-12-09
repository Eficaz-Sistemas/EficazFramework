using System;
using System.Linq.Expressions;
using EficazFramework.Extensions;

namespace EficazFramework.Validation.Fluent.Rules;

public abstract class Contatos<T> : Rules.ValidationRule<T> where T : class
{

    internal Contatos(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression) { }

    public override string Validate(T instance)
    {
        var value = Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value == null) return null;
        if (string.IsNullOrEmpty(value.ToString())) return null;
        return ValidateContato((string)value);
    }

    public abstract string ValidateContato(string value);
}

public class EMail<T> : Rules.Contatos<T> where T : class
{
    public EMail(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression) { }

    public override string ValidateContato(string value)
    {
        if (!value.IsValidEmailAddress()) { return Resources.Strings.Validation.InvalideMail; } else { return null; }
    }

}

/// <summary>
/// Conunto de métodos auxiliares para composição das regras de validação in-built
/// </summary>
public static partial class ValidatorUtils
{

    public static Validator<T> Mail<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) where T : class
    {
        validator.ValidationRules.Add(new EMail<T>(propertyexpression));
        return validator;
    }


}
