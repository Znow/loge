using Grpc.Core;
using Loge.Application.Interfaces;
using Loge.gRPC;

namespace Loge.gRPC.Services;

public class TransportOrdersService : TransportOrderService.TransportOrderServiceBase
{
    private readonly ITransportOrderService _transportOrderService;
    
    private readonly ILogger<TransportOrdersService> _logger;

    public TransportOrdersService(ILogger<TransportOrdersService> logger, ITransportOrderService transportOrderService)
    {
        _logger = logger;
        _transportOrderService = transportOrderService;
    }

    public override async Task<TransportOrderReply> GetTransportOrder(TransportOrderRequest request, ServerCallContext context)
    {
        var fetchedTransportOrders = await _transportOrderService.GetById(Guid.Parse(request.Id));
        
        if (fetchedTransportOrders == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Transport order not found"));
        }
        else
        {
            return new TransportOrderReply
            {
                Content = fetchedTransportOrders.Content,
                State = fetchedTransportOrders.State,
                Origin = fetchedTransportOrders.Origin,
                Destination = fetchedTransportOrders.Destination,
                Created = fetchedTransportOrders.Created.ToString()
            };
        }
    }
}