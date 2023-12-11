using Loge.Domain.Entities;
using Loge.Domain.Interfaces;

namespace Loge.Infrastructure.Repositories;

public class TechDomainRepository : Repository<TransportOrder>, ITransportOrderRepository
{
    public TechDomainRepository(LogeContext dbContext) : base(dbContext)
    {

    }
}