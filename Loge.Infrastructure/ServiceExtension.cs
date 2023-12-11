using Loge.Domain.Interfaces;
using Loge.Infrastructure;
using Loge.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LogeContext>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITransportOrderRepository, TransportOrderRepository>();

        return services;
    }
}