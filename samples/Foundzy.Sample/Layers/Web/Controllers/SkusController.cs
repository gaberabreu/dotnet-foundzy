using Foundzy.Sample.Layers.Core.SkuAggregate;
using Foundzy.Sample.Layers.UseCases.Skus.Create;
using Foundzy.Sample.Layers.Web.Requests;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Foundzy.Sample.Layers.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkusController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Ok<Sku>> Create([FromBody] CreateSkuRequest request)
    {
        var command = new CreateSkuCommand(request.Name);
        var result = await mediator.Send(command);
        return TypedResults.Ok(result);
    }
}
