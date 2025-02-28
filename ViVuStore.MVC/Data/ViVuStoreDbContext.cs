using Microsoft.EntityFrameworkCore;
using ViVuStore.MVC.Models;

namespace ViVuStore.MVC.Data;

public class ViVuStoreDbContext : DbContext
{
    public ViVuStoreDbContext(DbContextOptions<ViVuStoreDbContext> options) : base(options)
    {
    }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Category> Categories { get; set; }
}
