namespace Foundzy.Sample.Layers.Domain.SkuAggregate;

public class Sku(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;

    public Sku(string name)
        : this(Guid.NewGuid(), name) { }
}
