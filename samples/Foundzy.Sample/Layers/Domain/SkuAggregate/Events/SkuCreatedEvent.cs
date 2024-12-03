namespace Foundzy.Sample.Layers.Domain.SkuAggregate.Events;

public class SkuCreatedEvent(Sku sku) : DomainEventBase
{
    public Sku Sku { get; init; } = sku;
}
