using System;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Services.BaseServices;
using ViVuStore.MVC.UnitOfWork;

namespace ViVuStore.MVC.Services;

public interface ICategoryService: IBaseService<Category>
{

}

public class CategoryService: BaseService<Category>, ICategoryService
{
    public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
