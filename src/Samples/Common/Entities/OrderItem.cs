using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class OrderItem
{
    public Guid Id { get; set; } = Guid.Empty;

    public Guid? OrderID { get; set; }
    public Order? Order { get; set; }

    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }

    public decimal Price { get; set; } = 0;
    public decimal Amount { get; set; } = 0;
    public decimal Discount { get; set; } = 0;
    public decimal Balance { get; set; } = 0;
}
