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

    IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;

    IRepository<T> Repository<T>() where T : class;

    Task<int> SaveChangesAsync();

    int SaveChanges();
}