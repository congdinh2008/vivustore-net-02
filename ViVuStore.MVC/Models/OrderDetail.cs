using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViVuStore.MVC.Models;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class OrderDetail
{
    public required Guid OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public required Guid ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal Discount { get; set; }
}