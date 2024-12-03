using Foundzy.Sample.Layers.Domain.NotificationsAggregate;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate.Interfaces;
using Foundzy.Sample.Layers.Domain.SkuAggregate.Events;
using MediatR;

namespace Foundzy.Sample.Layers.Domain.SkuAggregate.Handlers;

public class SkuCreatedEventHandler(INotificationRepository repository) : INotificationHandler<SkuCreatedEvent>
{
    public async Task Handle(SkuCreatedEvent notification, CancellationToken cancellationToken)
    {
        await repository.Add(new Notification(notification.GetType().Name, $"Sku '{notification.Sku.Id}' was added."), cancellationToken);
    }
}
