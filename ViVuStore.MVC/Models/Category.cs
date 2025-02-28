using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStore.MVC.Models;

public class Category : BaseEntity
{
    [Required]
    [StringLength(255)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}
