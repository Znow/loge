using Loge.Domain.Interfaces;

namespace Loge.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LogeContext _dbContext;
    public ITransportOrderRepository TransportOrders { get; }

    public UnitOfWork(
        LogeContext dbContext,
        ITransportOrderRepository transportOrderRepository
    )
    {
        _dbContext = dbContext;
        TransportOrders = transportOrderRepository;
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }

}
