namespace Foundzy.Sample.Layers.Core.SkuAggregate;

public class Sku(Guid id, string name) : IAggregateRoot
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;

    public Sku(string name)
        : this(Guid.NewGuid(), name) { }
}
