using Foundzy.Sample.Layers.Domain.SkuAggregate;
using Foundzy.Sample.Layers.Domain.SkuAggregate.Interfaces;

namespace Foundzy.Sample.Layers.Infra.Data.Repositories;

public class SkuRepository : ISkuRepository
{
    private readonly List<Sku> _skus = [];
    public IReadOnlyCollection<Sku> Skus => _skus.AsReadOnly();

    public async Task Add(Sku sku, CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        _skus.Add(sku);
    }
}
