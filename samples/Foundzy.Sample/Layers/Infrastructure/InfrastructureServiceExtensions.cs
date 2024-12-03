using Foundzy.Sample.Layers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Foundzy.Sample.Layers.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<FoundzyContext>(
            options => options.UseInMemoryDatabase("Foundzy"));

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

        return services;
    }
}
