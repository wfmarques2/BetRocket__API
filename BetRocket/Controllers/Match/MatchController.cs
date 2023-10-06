using Application.Authorization;
using Application.CQRS.Match.Command.Request;
using Application.CQRS.Match.Queries.Request;
using BetRocket.Controllers.Match.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BetRocket.Controllers.Match;

[ApiController]
[Route("match")]
public class MatchController : ControllerBase
{
    [HttpPost("CreateMatch")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> CreateMatch(
        [FromServices] IMediator mediator,
        [FromBody] CreateMatchRequest request)
    {
        var matchResponse = await mediator.Send(request);

        return Ok(matchResponse);
    }

    [HttpGet("GetAllMatches")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetAllMatches(
        [FromServices] IMediator mediator,
        [FromQuery] GetAllMatchesRequest request)
    {
        var matches = await mediator.Send(request);

        return Ok(matches);
    }

    [HttpGet("GetMatchById")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetMatchById(
        [FromServices] IMediator mediator,
        [FromQuery] GetMatchByIdRequest request)
    {
        var match = await mediator.Send(request);

        return Ok(match);
    }

    [HttpPut("UpdateMatch")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> UpdateMatch(
        [FromServices] IMediator mediator,
        [FromBody] UpdateMatchRequest request)
    {
        var matchUpdated = await mediator.Send(request);

        return Ok(matchUpdated);
    }

    [HttpPut("FinishBet/{matchId:Guid}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> FinishBet(
    [FromServices] IMediator mediator,
    [FromRoute] Guid matchId,
    [FromBody] FinishMatchDto dto)
    {
        var request = new FinishMatchRequest
        {
            MatchId = matchId,
            WinnerSquadId = dto.WinnerSquadId,
        };

        var response = await mediator.Send(request);

        return Ok(response);
    }

    [HttpDelete("DeleteMatchById/{matchId:Guid}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> DeleteMatchById(
        [FromServices] IMediator mediator,
        [FromRoute] Guid matchId)
    {
        var request = new DeleteMatchByIdRequest
        {
            MatchId = matchId
        };

        var result = await mediator.Send(request);

        return Ok(result);
    }
}
