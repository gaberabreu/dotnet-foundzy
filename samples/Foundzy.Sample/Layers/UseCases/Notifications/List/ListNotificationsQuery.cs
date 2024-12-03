using Foundzy.Sample.Layers.Domain.NotificationsAggregate;

namespace Foundzy.Sample.Layers.UseCases.Notifications.List;

public record ListNotificationsQuery : IQuery<IEnumerable<Notification>>;
