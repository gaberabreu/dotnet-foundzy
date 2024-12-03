using Foundzy.Sample.Layers.Domain.SkuAggregate;
using Foundzy.Sample.Layers.Domain.SkuAggregate.Events;
using Foundzy.Sample.Layers.Domain.SkuAggregate.Interfaces;
using MediatR;

namespace Foundzy.Sample.Layers.UseCases.Skus.Create;

public class CreateSkuCommandHandler(ISkuRepository repository, IMediator mediator) : ICommandHandler<CreateSkuCommand, Sku>
{
    public async Task<Sku> Handle(CreateSkuCommand request, CancellationToken cancellationToken)
    {
        var sku = new Sku(request.Name);

        await repository.Add(sku, cancellationToken);

        var @event = new SkuCreatedEvent(sku);
        await mediator.Publish(@event, cancellationToken);

        return sku;
    }
}
