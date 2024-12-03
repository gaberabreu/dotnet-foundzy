namespace Foundzy.Sample.Layers.Domain.NotificationsAggregate.Interfaces;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetAll(CancellationToken cancellationToken = default);
    Task Add(Notification notification, CancellationToken cancellationToken = default);
}
