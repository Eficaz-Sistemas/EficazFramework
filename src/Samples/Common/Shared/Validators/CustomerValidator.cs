using EficazFramework.Validation.Fluent;
using EficazFramework.Validation.Fluent.Rules;
using Shared.DTOs;
using Shared.Interfaces;

namespace Shared.Validators;
public static class CustomerValidator
{
    public static IValidator Default()
    {
        var validator = new Validator<CustomerDto>();

        ((Validator<CustomerDto>)validator)
            .Required(c => c.Id)
            .Required(c => c.Name)
            .Required(c => c.Address.Street)
            .CustomExpression(c => !(c.Address as IValidatable).Validate()!.Any(), r => (r.Address as IValidatable).Validate()!.ToString());

        return validator;
    }
}
