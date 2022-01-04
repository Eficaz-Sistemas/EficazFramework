using System;
using System.ComponentModel.DataAnnotations;
using EficazFramework.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.Validation.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class IncricaoEstadual : ValidationAttribute
{
    public IncricaoEstadual(string UFPropertyName)
    {
        _uf = UFPropertyName;
    }

    private readonly string _uf;

    public string UFPropertyName
    {
        get
        {
            return _uf;
        }
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }
        else
        {
            if (_uf is null)
                return new ValidationResult(Resources.Strings.Validation.InvalidIE_NoUF);
            string clearNumber = value.ToString();
            string uf = Conversions.ToString(validationContext?.ObjectInstance.GetPropertyValue(_uf));
            if (string.IsNullOrEmpty(uf) || string.IsNullOrWhiteSpace(uf))
            {
                if (clearNumber.ToUpper().Contains("ISENTO"))
                    return ValidationResult.Success;
                else
                    return new ValidationResult(Resources.Strings.Validation.InvalidIE_NoUF);
            }
            bool result = clearNumber.IsValidInscricaoEstadual(uf);
            if (result == false)
                return new ValidationResult(string.Format(Resources.Strings.Validation.InvalidIE, uf.ToUpper()));
            else
                return ValidationResult.Success;
        }
    }
}
