using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLParserTask.Model;

public class ShoppingCart
{
    [Key] public int Id { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")] public Products Products { get; set; }

    public int OrderId { get; set; }

    [ForeignKey("OrderId")] public Order Order { get; set; }

    public int CountProduct { get; set; }
}