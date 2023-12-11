using Loge.Domain.Interfaces;

namespace Loge.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    ITransportOrderRepository TransportOrders { get; }

    int Save();

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}