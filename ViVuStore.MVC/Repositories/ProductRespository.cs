using ViVuStore.MVC.Data;
using ViVuStore.MVC.Models;

namespace ViVuStore.MVC.Repositories;

public class ProductRespository : GenericRespository<Product>, IProductRepository
{
    public ProductRespository(ViVuStoreDbContext context) : base(context)
    {
    }
}