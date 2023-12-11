using Loge.Application.Contracts;
using Loge.Domain.Entities;

namespace Loge.Application.Interfaces;

public interface ITransportOrderService
{
    Task<bool> Create(TransportOrderDto? transportOrder, CancellationToken cancellationToken = default);

    Task<IEnumerable<TransportOrderDto>> GetAll(CancellationToken cancellationToken = default);

    Task<TransportOrderDto?> GetById(Guid id, CancellationToken cancellationToken = default);

    Task<bool> Update(TransportOrderDto? transportOrder, CancellationToken cancellationToken = default);

    Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);
}