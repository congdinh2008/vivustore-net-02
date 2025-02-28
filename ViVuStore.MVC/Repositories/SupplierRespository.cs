using ViVuStore.MVC.Data;
using ViVuStore.MVC.Models;

namespace ViVuStore.MVC.Repositories;

public class SupplierRespository : GenericRespository<Supplier>, ISupplierRepository
{
    public SupplierRespository(ViVuStoreDbContext context) : base(context)
    {
    }
}