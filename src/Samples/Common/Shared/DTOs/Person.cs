using EficazFramework.Validation.Fluent;
using System.Text.Json.Serialization;

namespace Shared.DTOs;

public abstract class Person
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public IValidator? Validator { get; set; }

}
