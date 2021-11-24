using System;
using System.ComponentModel.DataAnnotations;
using EficazFramework.Extensions;

namespace EficazFramework.Validation.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class EMail : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            if (value.ToString().IsValidEmailAddress() == true)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(string.Format(Resources.Strings.Validation.InvalideMail, validationContext.DisplayName));
            }
        }
        else
        {
            return ValidationResult.Success;
            // O Atributo 'REQUIRED' é quem deve avaliar se é de preenchimento obrigatório ou não.
        }
    }

    public static ValidationResult ValidateAddress(object value, string field = "")
    {
        if (value != null)
        {
            if (value.ToString().IsValidEmailAddress() == true)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(string.Format(Resources.Strings.Validation.InvalideMail, field));
            }
        }
        else
        {
            return ValidationResult.Success;
            // O Atributo 'REQUIRED' é quem deve avaliar se é de preenchimento obrigatório ou não.
        }
    }
}
