namespace Foundzy.Sample.Layers.Domain.SkuAggregate.Events;

public record SkuCreatedEvent(Sku Sku) : IEvent;
