namespace Loge.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
    void Add(T? entity);
    void Delete(T entity);
    void Update(T entity);
}