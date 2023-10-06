using Application.CQRS.Squad.Commands.Request;
using Application.CQRS.Squad.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetRocket.Controllers;


[ApiController]
[Route("squad")]
public class SquadController : ControllerBase
{
    [HttpPost("CreateSquad")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> CreateSquad(
        [FromServices] IMediator mediator,
        [FromBody] CreateSquadRequest request)
    {
        var squadResponse = await mediator.Send(request);

        return Ok(squadResponse);
    }

    [HttpGet("GetAllSquads")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetAllSquads(
        [FromServices] IMediator mediator,
        [FromQuery] GetAllSquadsRequest request
        )
    {
        var squads = await mediator.Send(request);

        return Ok(squads);
    }

    [HttpGet("GetSquadById")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetSquadById(
        [FromServices] IMediator mediator,
        [FromQuery] GetSquadByIdRequest request)
    {
        var squadResponse = await mediator.Send(request);

        return Ok(squadResponse);
    }

    [HttpPut("UpdateSquad")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> UpdateSquad(
        [FromServices] IMediator mediator,
        [FromBody] UpdateSquadRequest request
        )
    {
        var squadResponse = await mediator.Send(request);

        return Ok(squadResponse);
    }


    [HttpDelete("DeleteSquadById")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> DeleteSquadById(
        [FromServices] IMediator mediator,
        [FromQuery] DeleteSquadByIdRequest request)
    {
        await mediator.Send(request);

        return NoContent();
    }
}
