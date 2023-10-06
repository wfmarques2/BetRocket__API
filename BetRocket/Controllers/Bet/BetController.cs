using Application.CQRS.Bets.Commands.Request;
using Application.CQRS.Bets.Queries.Request;
using BetRocket.Controllers.Bet.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetRocket.Controllers.Bet;

[Authorize]
[ApiController]
[Route("bet")]
public class BetController : ControllerBase
{

    [HttpGet]
    [Authorize]
    public IActionResult teste()
    {
        var userId = User.FindFirst("id")?.Value;

        return Ok(new { UserId = userId });
    }

    [HttpPost("CreateBet")]
    [Authorize(Policy = "MinAge")]
    public async Task<IActionResult> CreateBet(
        [FromServices] IMediator mediator,
        [FromBody] CreateBetDto dto
        )
    {
        try
        {
            var request = new CreateBetRequest
            {
                UserId = Guid.Parse(User.FindFirst("id")?.Value!),
                SquadId = dto.SelectedSquadId,
                MatchId = dto.MatchId,
                Amount  = dto.Amount
            };

            var betResponse = await mediator.Send(request);

            return Ok(betResponse);
        } 
        catch( Exception ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet("GetAllBets")]
    [Authorize(Policy = "MinAge")]
    public async Task<IActionResult> GetAllUserBets(
        [FromServices] IMediator mediator,
        [FromRoute] GetAllUserBetsRequest request)
    {
        request.UserId = Guid.Parse(User.FindFirst("id")?.Value!);

        var response = await mediator.Send(request);

        return Ok(response);
    }
}
