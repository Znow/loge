using Loge.Domain.Entities;

namespace Loge.Application.Interfaces;

public interface ITransportOrderService
{
    Task<bool> Create(TransportOrder? transportOrder, CancellationToken cancellationToken = default);

    Task<IEnumerable<TransportOrder>> GetAll(CancellationToken cancellationToken = default);

    Task<TransportOrder?> GetById(Guid id, CancellationToken cancellationToken = default);

    Task<bool> Update(TransportOrder? transportOrder, CancellationToken cancellationToken = default);

    Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);
}