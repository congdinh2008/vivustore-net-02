using Microsoft.EntityFrameworkCore;
using ViVuStore.MVC.Data;
using ViVuStore.MVC.Models;

namespace ViVuStore.MVC.Repositories;

public class GenericRespository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ViVuStoreDbContext _context;

    private readonly DbSet<T> _dbSet;
    public GenericRespository(ViVuStoreDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(Guid id)
    {
        var existingEntity = GetById(id) ?? throw new InvalidOperationException($"{typeof(T).Name} not found");
        _dbSet.Remove(existingEntity);
    }

    public IEnumerable<T> GetAll()
    {
        return [.. _dbSet];
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public T? GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}