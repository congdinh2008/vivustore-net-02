using System;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Services.BaseServices;
using ViVuStore.MVC.UnitOfWork;

namespace ViVuStore.MVC.Services;

public interface ISupplierService: IBaseService<Supplier>
{

}

public class SupplierService: BaseService<Supplier>, ISupplierService
{
    public SupplierService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
