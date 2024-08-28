using EficazFramework.Validation.Fluent;
using EficazFramework.Validation.Fluent.Rules;
using Shared.DTOs;

namespace Shared.Validators;
public static class AddressValidator
{
    public static IValidator Default()
    {
        var validator = new Validator<AddressDto>();

        ((Validator<AddressDto>)validator)
            .Required(v => v.Street)
            .Required(v => v.ZipCode)
            .Required(v => v.City)
            .Required(v => v.State);

        return validator;
    }
}
