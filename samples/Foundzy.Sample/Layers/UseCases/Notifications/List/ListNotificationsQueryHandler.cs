using Foundzy.Sample.Layers.Domain.NotificationsAggregate;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate.Interfaces;

namespace Foundzy.Sample.Layers.UseCases.Notifications.List;

public class ListNotificationsQueryHandler(INotificationRepository repository) : IQueryHandler<ListNotificationsQuery, IEnumerable<Notification>>
{
    public async Task<IEnumerable<Notification>> Handle(ListNotificationsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAll(cancellationToken);
    }
}
