using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;

namespace Foundzy.Sample.Infra.Data.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly List<Notification> _notifications = [];
    public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

    public async Task<IEnumerable<Notification>> GetAll(CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        return _notifications;
    }

    public async Task Add(Notification notification, CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        _notifications.Add(notification);
    }
}
