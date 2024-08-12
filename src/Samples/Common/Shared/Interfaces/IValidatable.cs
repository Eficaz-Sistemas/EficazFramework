using EficazFramework.Validation.Fluent;
using System.Text.Json.Serialization;

namespace Shared.Interfaces;

public interface IValidatable
{
    [JsonIgnore()]
    IValidator? Validator { get; }

    public sealed ValidationResult? Validate() => Validator?.Validate(this);
}
