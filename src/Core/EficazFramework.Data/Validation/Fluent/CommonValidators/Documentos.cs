using System;
using EficazFramework.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.Validation.Fluent.Rules;

public abstract class Documentos<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>s
    /// Regra de validação contra valores e/ou referências nulas ou vazias
    /// </summary>
    internal Documentos(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression) { }

    public override string Validate(T instance)
    {
        var value = Property.Invoke(instance); // instance.GetPropertyValue(Me.PropertyName)
        if (value == null) return null;
        return ValidateDocumento((string)value, new object[] { instance });
    }

    public abstract string ValidateDocumento(string value, object[] args = null);
}

public class CNPJ<T> : Rules.Documentos<T> where T : class
{
    public CNPJ(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression) { }

    public override string ValidateDocumento(string value, object[] args = null)
    {
        if (!value.IsValidCNPJ()) { return Resources.Strings.Validation.InvalidCNPJ; } else { return null; }
    }

}

public class CPF<T> : Rules.Documentos<T> where T : class
{
    public CPF(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression) { }

    public override string ValidateDocumento(string value, object[] args = null)
    {
        if (!value.IsValidCPF()) { return Resources.Strings.Validation.InvalidCPF; } else { return null; }
    }

}

public class CNPJouCPF<T> : Rules.Documentos<T> where T : class
{
    public CNPJouCPF(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression) { }

    public override string ValidateDocumento(string value, object[] args = null)
    {
        if (!(value.IsValidCNPJ() || value.IsValidCPF())) { return Resources.Strings.Validation.InvalidCNPJorCPF; } else { return null; }
    }

}

public class PIS<T> : Rules.Documentos<T> where T : class
{
    public PIS(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) : base(propertyexpression) { }

    public override string ValidateDocumento(string value, object[] args = null)
    {
        if (!value.IsValidPISePASEP()) { return Resources.Strings.Validation.InvalidPIS; } else { return null; }
    }

}

public class InscrEstadual<T> : Rules.Documentos<T> where T : class
{
    public System.Linq.Expressions.Expression<Func<T, object>> UfExpression { get; set; } = null;

    public InscrEstadual(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression,
                         System.Linq.Expressions.Expression<Func<T, object>> uf_expression) : base(propertyexpression)
    {
        UfExpression = uf_expression;
    }

    public override string ValidateDocumento(string value, object[] args = null)
    {
        var uf = UfExpression.Invoke((T)(args[0]));
        if (uf == null) return Resources.Strings.Validation.InvalidIE_NoUF;
        if (!value.IsValidInscricaoEstadual((string)uf)) { return string.Format(Resources.Strings.Validation.InvalidIE, (string)uf); } else { return null; }
    }

}


/// <summary>
/// Conunto de métodos auxiliares para composição das regras de validação in-built
/// </summary>
public static partial class ValidatorUtils
{

    public static Validator<T> CNPJ<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) where T : class
    {
        validator.ValidationRules.Add(new CNPJ<T>(propertyexpression));
        return validator;
    }

    public static Validator<T> CPF<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) where T : class
    {
        validator.ValidationRules.Add(new CPF<T>(propertyexpression));
        return validator;
    }

    public static Validator<T> CNPJouCPF<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) where T : class
    {
        validator.ValidationRules.Add(new CNPJouCPF<T>(propertyexpression));
        return validator;
    }

    public static Validator<T> PisPasep<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression) where T : class
    {
        validator.ValidationRules.Add(new PIS<T>(propertyexpression));
        return validator;
    }

    public static Validator<T> InscricaoEstadual<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, object>> propertyexpression,
                                                                                 System.Linq.Expressions.Expression<Func<T, object>> ufexpression) where T : class
    {
        validator.ValidationRules.Add(new InscrEstadual<T>(propertyexpression, ufexpression));
        return validator;
    }

}
