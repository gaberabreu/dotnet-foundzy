using Foundzy.Sample.Domain.Entities;

namespace Foundzy.Sample.Domain.Interfaces;

public interface ISkuRepository
{
    Task Add(Sku sku, CancellationToken cancellationToken = default);
}
