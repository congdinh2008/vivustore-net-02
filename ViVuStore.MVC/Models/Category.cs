using System.ComponentModel.DataAnnotations;

namespace ViVuStore.MVC.Models;

public class Category : BaseEntity
{
    [Required]
    [StringLength(255)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }
}
