using ViVuStore.MVC.Models;

namespace ViVuStore.MVC.Repositories;

public interface IGenericRepository<T> where T: BaseEntity
{
    IEnumerable<T> GetAll();

    Task<IEnumerable<T>> GetAllAsync();

    T? GetById(Guid id);

    Task<T?> GetByIdAsync(Guid id);

    void Add(T entity);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(Guid id);
}
