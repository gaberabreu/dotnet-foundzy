using Foundzy.Sample.Layers.Core.SkuAggregate;

namespace Foundzy.Sample.Layers.UseCases.Skus.Create;

public record CreateSkuCommand(string Name) : ICommand<Sku>;
