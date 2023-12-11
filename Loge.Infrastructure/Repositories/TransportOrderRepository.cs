using Loge.Domain.Entities;
using Loge.Domain.Interfaces;

namespace Loge.Infrastructure.Repositories;

public class TransportOrderRepository : Repository<TransportOrder>, ITransportOrderRepository
{
    public TransportOrderRepository(LogeContext dbContext) : base(dbContext)
    {

    }
}