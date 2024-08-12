using EficazFramework.Validation.Fluent;

namespace Shared.DTOs;

public abstract class Person
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public IValidator? Validator { get; set; }

}
