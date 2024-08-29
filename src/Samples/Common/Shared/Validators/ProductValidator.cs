using EficazFramework.Validation.Fluent;
using EficazFramework.Validation.Fluent.Rules;
using Shared.DTOs;

namespace Shared.Validators;
public static class ProductValidator
{
    public static IValidator Default()
    {
        var validator = new Validator<ProductDto>();

        ((Validator<ProductDto>)validator)
            .Required(p => p.Id)
            .Required(p => p.Name)
            .Required(p => p.Price)
            .Range(p => p.Price, 0.0m, 15999.99m);

        return validator;
    }
}
