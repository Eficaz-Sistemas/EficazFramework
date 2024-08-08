namespace Entities;
public class Product
{
    public Guid Id { get; set; } = Guid.Empty;
    public string? Name { get; set; }
    public decimal? Price { get; set; }
}
