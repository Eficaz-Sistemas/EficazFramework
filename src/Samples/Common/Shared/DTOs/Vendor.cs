using Shared.Interfaces;

namespace Shared.DTOs;

public sealed class VendorDto : Person, IValidatable
{
    public VendorDto()  =>
        Validator = Validators.VendorValidator.Default();
}
