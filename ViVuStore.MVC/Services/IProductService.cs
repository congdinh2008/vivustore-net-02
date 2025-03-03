using System;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Services.BaseServices;
using ViVuStore.MVC.UnitOfWork;

namespace ViVuStore.MVC.Services;

public interface IProductService: IBaseService<Product>
{

}

public class ProductService: BaseService<Product>, IProductService
{
    public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
