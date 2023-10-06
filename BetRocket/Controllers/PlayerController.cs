using Application.CQRS.Player.Command.Request;
using Application.CQRS.Player.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetRocket.Controllers;

[ApiController]
[Route("player")]
public class PlayerController : ControllerBase
{
    [HttpPost("CreatePlayer")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> CreatePlayer(
        [FromServices] IMediator mediator,
        [FromBody] CreatePlayerRequest request
        )
    {
        var playerResponse = await mediator.Send(request);

        return Ok(playerResponse);
    }

    [HttpGet("GetAllPlayers")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetAllPlayers(
        [FromServices] IMediator mediator,
        [FromQuery] GetAllPlayersRequest request
        )
    {
        var players = await mediator.Send(request);

        return Ok(players);
    }

    [HttpGet("GetPlayerById")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetPlayerById(
        [FromServices] IMediator mediator,
        [FromQuery] GetPlayerByIdRequest request)
    {
        var playerResponse = await mediator.Send(request);

        return Ok(playerResponse);
    }

    [HttpPut("UpdatePlayer")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> UpdatePlayer(
        [FromServices] IMediator mediator,
        [FromBody] UpdatePlayerRequest request
        )
    {
        var playerResponse = await mediator.Send(request);

        return Ok(playerResponse);
    }

    [HttpDelete("DeleteGameById")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> DeletePlayerById(
        [FromServices] IMediator mediator,
        [FromQuery] DeletePlayerByIdRequest request)
    {
        await mediator.Send(request);

        return NoContent();
    }
}
