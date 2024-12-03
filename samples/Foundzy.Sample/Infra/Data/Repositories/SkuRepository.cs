using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;

namespace Foundzy.Sample.Infra.Data.Repositories;

public class SkuRepository : ISkuRepository
{
    public ICollection<Sku> Skus = [];

    public async Task Add(Sku sku, CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        Skus.Add(sku);
    }
}
