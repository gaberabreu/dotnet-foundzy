using Foundzy.Sample.Layers.Core.NotificationsAggregate;
using Foundzy.Sample.Layers.Core.SkuAggregate;
using Microsoft.EntityFrameworkCore;

namespace Foundzy.Sample.Layers.Infrastructure.Data;

public class FoundzyContext(DbContextOptions<FoundzyContext> options) : DbContext(options)
{
    public DbSet<Sku> Skus => Set<Sku>();
    public DbSet<Notification> Notifications => Set<Notification>();
}
