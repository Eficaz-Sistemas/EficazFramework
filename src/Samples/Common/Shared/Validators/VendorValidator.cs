using EficazFramework.Validation.Fluent;
using EficazFramework.Validation.Fluent.Rules;
using Shared.DTOs;

namespace Shared.Validators;
public static class VendorValidator
{
    public static IValidator Default()
    {
        var validator = new Validator<VendorDto>();

        ((Validator<VendorDto>)validator)
            .Required(v => v.Id)
            .Required(v => v.Name);

        return validator;
    }
}
