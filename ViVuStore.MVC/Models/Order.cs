using System.ComponentModel.DataAnnotations;

namespace ViVuStore.MVC.Models;

public class Order: BaseEntity
{
    [Required]
    public required DateTime OrderDate { get; set; }

    [Required]
    [StringLength(500)]
    public required string ShippedAddress { get; set; }

    [Required]
    public DateTime ExpectedShippedDate { get; set; }

    public DateTime? ActualShippedDate { get; set; }

    [Required]
    [StringLength(12)]
    public required string PhoneNumber { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = [];
}