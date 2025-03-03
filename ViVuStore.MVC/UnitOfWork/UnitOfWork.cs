
using Microsoft.EntityFrameworkCore;
using ViVuStore.MVC.Data;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Repositories;

namespace ViVuStore.MVC.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ViVuStoreDbContext _context;
    private bool _disposed = false;

    public UnitOfWork(ViVuStoreDbContext context)
    {
        _context = context;
    }

    public ViVuStoreDbContext Context => _context;

    private IGenericRepository<Category>? _categoryRepository;

    public IGenericRepository<Category> CategoryRepository => _categoryRepository ??= new GenericRepository<Category>(_context);

    private IGenericRepository<Supplier>? _supplierRepository;

    public IGenericRepository<Supplier> SupplierRepository => _supplierRepository ??= new GenericRepository<Supplier>(_context);

    private IGenericRepository<Product>? _productRepository;

    public IGenericRepository<Product> ProductRepository => _productRepository ??= new GenericRepository<Product>(_context);

    private IGenericRepository<Order>? _orderRepository;

    public IGenericRepository<Order> OrderRepository => _orderRepository ??= new GenericRepository<Order>(_context);

    private IRepository<OrderDetail>? _orderDetailRepository;

    public IRepository<OrderDetail> OrderDetailRepository => _orderDetailRepository ??= new Repository<OrderDetail>(_context);

    public async Task<int> SaveChangesAsync()
    {
        BeforeSaveChanges();
        return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        BeforeSaveChanges();
        return _context.SaveChanges();
    }

    private void BeforeSaveChanges()
    {
        var entities = _context.ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
        
        foreach (var entity in entities)
        {
            var baseEntity = (BaseEntity)entity.Entity;
            switch (entity.State)
            {
                case EntityState.Added:
                    baseEntity.InsertedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    baseEntity.UpdatedAt = DateTime.Now;
                    break;
            }
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}