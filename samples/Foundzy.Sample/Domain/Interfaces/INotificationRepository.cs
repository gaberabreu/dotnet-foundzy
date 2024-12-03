using Foundzy.Sample.Domain.Entities;

namespace Foundzy.Sample.Domain.Interfaces;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetAll(CancellationToken cancellationToken = default);
    Task Add(Notification notification, CancellationToken cancellationToken = default);
}
