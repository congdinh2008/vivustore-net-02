using ViVuStore.MVC.Data;
using ViVuStore.MVC.Models;

namespace ViVuStore.MVC.Repositories;

public class CategoryRespository : GenericRespository<Category>, ICategoryRepository
{
    public CategoryRespository(ViVuStoreDbContext context) : base(context)
    {
    }
}