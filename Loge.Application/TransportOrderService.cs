using AutoMapper;
using Loge.Application.Contracts;
using Loge.Application.Interfaces;
using Loge.Domain.Entities;
using Loge.Infrastructure;

namespace Loge.Application;

public class TransportOrderService : ITransportOrderService
{
    public IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TransportOrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Create(TransportOrderDto? transportOrder, CancellationToken cancellationToken = default)
    {
        if (transportOrder is null)
        {
            return false;
        }

        transportOrder.Id = Guid.NewGuid();
        
        var mappedTransportOrder = _mapper.Map<TransportOrder>(transportOrder);

        _unitOfWork.TransportOrders.Add(mappedTransportOrder);

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

    public async Task<IEnumerable<TransportOrderDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var transportOrders = await _unitOfWork.TransportOrders.GetAll(cancellationToken);
        
        var mappedTransportOrders = _mapper.Map<IEnumerable<TransportOrderDto>>(transportOrders);

        return mappedTransportOrders;
    }

    public async Task<TransportOrderDto?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
        {
            return null;
        }

        var transportOrder = await _unitOfWork.TransportOrders.GetById(id, cancellationToken);
        
        var mappedTransportOrder = _mapper.Map<TransportOrderDto>(transportOrder);

        return mappedTransportOrder;
    }

    public async Task<bool> Update(TransportOrderDto? transportOrder, CancellationToken cancellationToken = default)
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
