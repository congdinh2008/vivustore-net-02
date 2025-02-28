using System.ComponentModel.DataAnnotations;

namespace ViVuStore.MVC.Models;

public class Supplier : BaseEntity
{
    [Required]
    [StringLength(255)]
    public required string Name { get; set; }
    
    [Required]
    [StringLength(12)]
    public required string PhoneNumber { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }
}
