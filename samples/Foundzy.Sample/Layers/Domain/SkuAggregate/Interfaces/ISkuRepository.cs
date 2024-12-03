namespace Foundzy.Sample.Layers.Domain.SkuAggregate.Interfaces;

public interface ISkuRepository
{
    Task Add(Sku sku, CancellationToken cancellationToken = default);
}
