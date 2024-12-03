using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;
using MediatR;

namespace Foundzy.Sample.Application.Events;

public record SkuAddedEvent(Sku Sku) : IEvent;

public class SkuAddedEventHandler(INotificationRepository repository) : INotificationHandler<SkuAddedEvent>
{
    public async Task Handle(SkuAddedEvent notification, CancellationToken cancellationToken)
    {
        await repository.Add(new Notification(notification.GetType().Name, $"Sku '{notification.Sku.Id}' was added."), cancellationToken);
    }
}
