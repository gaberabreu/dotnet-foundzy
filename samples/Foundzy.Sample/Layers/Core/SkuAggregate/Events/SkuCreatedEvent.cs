﻿namespace Foundzy.Sample.Layers.Core.SkuAggregate.Events;

public class SkuCreatedEvent(Sku sku) : DomainEventBase
{
    public Sku Sku { get; init; } = sku;
}
