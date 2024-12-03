using Foundzy.Sample.Layers.Core.NotificationsAggregate;

namespace Foundzy.Sample.Layers.UseCases.Notifications.List;

public class ListNotificationsQueryHandler(IReadRepository<Notification> repository) : IQueryHandler<ListNotificationsQuery, IEnumerable<Notification>>
{
    public async Task<IEnumerable<Notification>> Handle(ListNotificationsQuery request, CancellationToken cancellationToken)
    {
        return await repository.ListAsync(cancellationToken);
    }
}
