using Foundzy.Sample.Layers.Core.NotificationsAggregate;

namespace Foundzy.Sample.Layers.UseCases.Notifications.List;

public record ListNotificationsQuery : IQuery<IEnumerable<Notification>>;
