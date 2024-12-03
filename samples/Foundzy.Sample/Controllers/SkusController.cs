using Foundzy.Sample.Application.Commands;
using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Requests;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Foundzy.Sample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkusController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Ok<Sku>> Add([FromBody] AddSkuRequest request)
    {
        var command = new AddSkuCommand(request.Name);
        var result = await mediator.Send(command);
        return TypedResults.Ok(result);
    }
}
