using EficazFramework.Validation.Fluent;
using EficazFramework.Validation.Fluent.Rules;
using Shared.DTOs;

namespace Shared.Validators;

public static class TagValidator
{
    public static IValidator Default()
    {
        var validator = new Validator<TagDto>();
        ((Validator<TagDto>)validator)
            .Required(p => p.Id)
            .Required(p => p.Name)
            .MaxLength(p => p.Id, 50)
            .MaxLength(p => p.Name, 100);
        return validator;
    }
}
