using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;

namespace Foundzy.Sample.Infra.Data.Repositories;

public class NotificationRepository : INotificationRepository
{
    public ICollection<Notification> Notifications = [];

    public async Task<IEnumerable<Notification>> GetAll(CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        return Notifications;
    }

    public async Task Add(Notification notification, CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        Notifications.Add(notification);
    }
}
