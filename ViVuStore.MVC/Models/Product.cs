using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStore.MVC.Models;

public class Product : BaseEntity
{
    [Required]
    [StringLength(255)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [StringLength(255)]
    public string? Thumbnail { get; set; }

    public bool IsDiscontinued { get; set; }

    public Guid CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public Guid SupplierId { get; set; }

    public virtual Supplier? Supplier { get; set; }
}