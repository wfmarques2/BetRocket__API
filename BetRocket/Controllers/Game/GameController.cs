using Application.CQRS.Game.Commands.Request;
using Application.CQRS.Game.Queries.Request;
using BetRocket.Controllers.Game.Dtos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetRocket.Controllers.Game;

[ApiController]
[Route("game")]
public class GameController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> CreateGame(
        [FromServices] IMediator mediator,
        [FromServices] IUnitOfWork unitOfWork,
        [FromBody] CreateGameRequest request)
    {
        var gameResponse = await mediator.Send(request);
        await unitOfWork.Commit();

        return Ok(gameResponse);
    }

    [HttpGet("GetAllGames")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetAllGames(
        [FromServices] IMediator mediator,
        [FromRoute] GetAllGamesRequest request)
    {
        var response = await mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("GetGameById/{gameId:guid}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetGameById(
        [FromServices] IMediator mediator,
        [FromRoute] Guid gameId)
    {
        var request = new GetGameByIdRequest
        {
            GameId = gameId
        };

        var response = await mediator.Send(request);

        return Ok(response);
    }

    [HttpPut("UpdateGame/{gameId:Guid}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> UpdateGame(
        [FromServices] IMediator mediator,
        [FromRoute] Guid gameId,
        [FromBody] UpdateGameDto dto)
    {
        var request = new UpdateGameRequest
        {
            GameId = gameId,
            Name = dto.Name
        };

        var response = await mediator.Send(request);

        return Ok(response);
    }

    [HttpDelete("DeleteGame/{gameId:Guid}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> DeleteGame(
        [FromServices] IMediator mediator,
        [FromRoute] Guid gameId)
    {
        var request = new DeleteGameByIdRequest
        {
            GameId = gameId
        };

        var response = await mediator.Send(request);

        return Ok(response);
    }
}
