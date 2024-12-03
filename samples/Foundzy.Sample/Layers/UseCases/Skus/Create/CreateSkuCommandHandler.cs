using Foundzy.Sample.Layers.Core.SkuAggregate;
using Foundzy.Sample.Layers.Core.SkuAggregate.Events;
using MediatR;

namespace Foundzy.Sample.Layers.UseCases.Skus.Create;

public class CreateSkuCommandHandler(IRepository<Sku> repository, IMediator mediator) : ICommandHandler<CreateSkuCommand, Sku>
{
    public async Task<Sku> Handle(CreateSkuCommand request, CancellationToken cancellationToken)
    {
        var sku = new Sku(request.Name);

        await repository.AddAsync(sku, cancellationToken);

        var @event = new SkuCreatedEvent(sku);
        await mediator.Publish(@event, cancellationToken);

        return sku;
    }
}
