using Microsoft.EntityFrameworkCore;

namespace ViVuStore.MVC.Data;

public class ViVuStoreDbContext: DbContext
{
    public ViVuStoreDbContext(DbContextOptions<ViVuStoreDbContext> options) : base(options)
    {
    }
}
