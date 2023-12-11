using Loge.Application.Interfaces;
using Loge.Domain.Entities;
using Loge.Infrastructure;

namespace Loge.Application;

public class TransportOrderService : ITransportOrderService
{
    public IUnitOfWork _unitOfWork;

    public TransportOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Create(TransportOrder? transportOrder, CancellationToken cancellationToken = default)
    {
        if (transportOrder is null)
        {
            return false;
        }

        transportOrder.Id = Guid.NewGuid();

        _unitOfWork.TransportOrders.Add(transportOrder);

        var result = await _unitOfWork.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
        {
            return false;
        }

        var transportOrder = await _unitOfWork.TransportOrders.GetById(id, cancellationToken);

        if (transportOrder is null)
        {
            return false;
        }

        _unitOfWork.TransportOrders.Delete(transportOrder);

        var result = await _unitOfWork.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async Task<IEnumerable<TransportOrder>> GetAll(CancellationToken cancellationToken = default)
    {
        var transportOrders = await _unitOfWork.TransportOrders.GetAll(cancellationToken);

        return transportOrders;
    }

    public async Task<TransportOrder?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
        {
            return null;
        }

        var transportOrder = await _unitOfWork.TransportOrders.GetById(id, cancellationToken);

        return transportOrder;
    }

    public async Task<bool> Update(TransportOrder? transportOrder, CancellationToken cancellationToken = default)
    {
        if (transportOrder is null || transportOrder.Id == Guid.Empty)
        {
            return false;
        }

        var fetchedTransportOrder = await _unitOfWork.TransportOrders.GetById(transportOrder.Id, cancellationToken);

        if (fetchedTransportOrder is null)
        {
            return false;
        }

        fetchedTransportOrder.State = transportOrder.State;
        fetchedTransportOrder.Destination = transportOrder.Destination;
        fetchedTransportOrder.Content = transportOrder.Content;
        fetchedTransportOrder.Origin = transportOrder.Origin;

        _unitOfWork.TransportOrders.Update(fetchedTransportOrder);

        var result = await _unitOfWork.SaveAsync(cancellationToken);

        return result > 0;
    }
}
