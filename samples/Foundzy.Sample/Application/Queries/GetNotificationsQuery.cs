using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;

namespace Foundzy.Sample.Application.Queries;

public record GetNotificationsQuery : IQuery<IEnumerable<Notification>>;

public class GetNotificationsQueryHandler(INotificationRepository repository) : IQueryHandler<GetNotificationsQuery, IEnumerable<Notification>>
{
    public async Task<IEnumerable<Notification>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken = default)
    {
        return await repository.GetAll(cancellationToken);
    }
}