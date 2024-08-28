using Shared.Interfaces;

namespace Shared.DTOs;

public sealed class CustomerDto : Person, IValidatable
{
    public CustomerDto()  =>
        Validator = Validators.CustomerValidator.Default();

    public AddressDto Address { get; set; } = new();

}
