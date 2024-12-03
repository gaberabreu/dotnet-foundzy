using Foundzy.Sample.Layers.Core.NotificationsAggregate;
using Foundzy.Sample.Layers.Core.SkuAggregate.Events;
using MediatR;

namespace Foundzy.Sample.Layers.Core.SkuAggregate.Handlers;

public class SkuCreatedEventHandler(IRepository<Notification> repository) : INotificationHandler<SkuCreatedEvent>
{
    public async Task Handle(SkuCreatedEvent notification, CancellationToken cancellationToken)
    {
        await repository.AddAsync(new Notification(notification.DateOccurred, notification.GetType().Name, $"Sku '{notification.Sku.Id}' was created."), cancellationToken);
    }
}
