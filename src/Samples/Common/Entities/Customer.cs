namespace Entities;

public class Customer : Person
{
    public Address Address { get; set; } = new();
}
