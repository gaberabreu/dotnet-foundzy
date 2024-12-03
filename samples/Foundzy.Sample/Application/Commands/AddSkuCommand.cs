using Foundzy.Sample.Application.Events;
using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;
using MediatR;

namespace Foundzy.Sample.Application.Commands;

public record AddSkuCommand(string Name) : ICommand<Sku>;

public class AddSkuCommandHandler(ISkuRepository repository, IMediator mediator) : ICommandHandler<AddSkuCommand, Sku>
{
    public async Task<Sku> Handle(AddSkuCommand request, CancellationToken cancellationToken = default)
    {
        var sku = new Sku(request.Name);

        await repository.Add(sku, cancellationToken);

        var @event = new SkuAddedEvent(sku);
        await mediator.Publish(@event, cancellationToken);

        return sku;
    }
}
