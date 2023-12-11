using Loge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Loge.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly LogeContext Context;

    protected Repository(LogeContext context)
    {
        Context = context;
    }

    public async Task<T?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        object?[] ids = { id };

        return await Context.Set<T>().FindAsync(ids, cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
    {
        return await Context
            .Set<T>()
            .AsTracking()
            .ToListAsync(cancellationToken);
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        Context.Set<T>().Update(entity);
    }
}