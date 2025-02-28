namespace ViVuStore.MVC.Models;

public class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime InsertedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    public bool IsActive { get; set; }
}