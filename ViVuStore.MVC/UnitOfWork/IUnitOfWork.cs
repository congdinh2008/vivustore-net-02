using ViVuStore.MVC.Data;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Repositories;

namespace ViVuStore.MVC.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ViVuStoreDbContext Context { get; }

    IGenericRepository<Category> CategoryRepository { get; }

    IGenericRepository<Supplier> SupplierRepository { get; }

    IGenericRepository<Product> ProductRepository { get; }

    IGenericRepository<Order> OrderRepository { get; }

    IRepository<OrderDetail> OrderDetailRepository { get; }

    Task<int> SaveChangesAsync();

    int SaveChanges();
}