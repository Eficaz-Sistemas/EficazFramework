namespace Entities;

public abstract class Person
{
    public Guid Id { get; set; } = Guid.Empty;
    public string? Name { get; set; }
}
