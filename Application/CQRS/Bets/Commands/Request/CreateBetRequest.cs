using Application.CQRS.Bets.Commands.Response;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Bets.Commands.Request;

public class CreateBetRequest : IRequest<CreateBetResponse>
{
    public Guid UserId { get; set; }

    public Guid SquadId { get; set; }

    public Guid MatchId { get; set; }

    public decimal Amount { get; set; }

    public static implicit operator ModelBet(CreateBetRequest request)
    {
        return new ModelBet
        {
            UserId = request.UserId,
            SquadId = request.SquadId,
            MatchId = request.MatchId,
            Amount = request.Amount,
        };
    }
}
