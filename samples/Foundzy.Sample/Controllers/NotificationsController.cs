using Foundzy.Sample.Application.Queries;
using Foundzy.Sample.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Foundzy.Sample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<Notification>>> Get()
    {
        var query = new GetNotificationsQuery();
        var result = await mediator.Send(query);
        return TypedResults.Ok(result);
    }
}