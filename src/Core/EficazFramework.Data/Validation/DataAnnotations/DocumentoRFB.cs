using EficazFramework.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace EficazFramework.Validation.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class DocumentoRFB : ValidationAttribute
{
    public DocumentoRFB(EficazFramework.Enums.DocumentosRFB tipo)
    {
        Tipo = tipo;
    }

    public EficazFramework.Enums.DocumentosRFB Tipo { get; set; } = EficazFramework.Enums.DocumentosRFB.Ambos;

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string documento = value.ToString();
            documento = documento.Replace(".", string.Empty);
            documento = documento.Replace(",", string.Empty);
            documento = documento.Replace("-", string.Empty);
            documento = documento.Replace("_", string.Empty);
            documento = documento.Replace("/", string.Empty);
            documento = documento.Replace(@"\", string.Empty);
            documento = documento.Replace("+", string.Empty);
            documento = documento.Replace("=", string.Empty);
            documento = documento.Replace("@", string.Empty);
            documento = documento.Replace("#", string.Empty);
            documento = documento.Replace("$", string.Empty);
            documento = documento.Replace("%", string.Empty);
            documento = documento.Replace("&", string.Empty);
            documento = documento.Replace("*", string.Empty);
            documento = documento.Replace("(", string.Empty);
            documento = documento.Replace(")", string.Empty);
            if (Tipo == EficazFramework.Enums.DocumentosRFB.CNPJ)
            {
                if (documento.IsValidCNPJ() == true)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(Resources.Strings.Validation.InvalidCNPJ);
            }
            else if (Tipo == EficazFramework.Enums.DocumentosRFB.CPF)
            {
                if (documento.IsValidCPF() == true)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(Resources.Strings.Validation.InvalidCPF);
            }
            else if (documento.Trim().Length == 14)
            {
                if (documento.IsValidCNPJ() == true)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(Resources.Strings.Validation.InvalidCNPJ);
            }
            else if (documento.Trim().Length == 11)
            {
                if (documento.IsValidCPF() == true)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(Resources.Strings.Validation.InvalidCPF);
            }
            else
            {
                return new ValidationResult(Resources.Strings.Validation.InvalidCNPJorCPF);
            }
        }
        else
        {
            return ValidationResult.Success;
        }
    }

    public override bool IsValid(object value)
    {
        var result = IsValid(value, null);
        if (result == ValidationResult.Success || result == null)
            return true;
        else
            return false;
    }
}
