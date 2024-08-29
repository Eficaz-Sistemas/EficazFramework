using EficazFramework.Validation.Fluent;
using Shared.Interfaces;
using System.Text.Json.Serialization;

namespace Shared.DTOs;

public class AddressDto : IValidatable
{
    public AddressDto() =>
        Validator = Validators.AddressValidator.Default();

    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }


    [JsonIgnore]
    public IValidator? Validator { get; set; }

}
