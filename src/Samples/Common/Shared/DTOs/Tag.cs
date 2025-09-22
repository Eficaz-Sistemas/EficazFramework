using EficazFramework.Validation.Fluent;
using Shared.Interfaces;
using System.Text.Json.Serialization;

namespace Shared.DTOs;

public sealed class TagDto : IValidatable
{
    public TagDto() =>
        Validator = null;

    public string Id { get; set; } = string.Empty;

    public string? Name { get; set; }

    [JsonIgnore]
    public IValidator? Validator { get; set; }
}
