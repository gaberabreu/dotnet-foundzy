using Foundzy.Sample.Layers.Domain.NotificationsAggregate;
using Foundzy.Sample.Layers.UseCases.Notifications.List;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Foundzy.Sample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<Notification>>> List()
    {
        var query = new ListNotificationsQuery();
        var result = await mediator.Send(query);
        return TypedResults.Ok(result);
    }
}
