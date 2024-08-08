namespace Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public Guid? VendorID { get; set; }
    public Vendor? Vendor { get; set; }

    public Guid? CustomerID { get; set; }
    public Customer? Customer { get; set; }

}
