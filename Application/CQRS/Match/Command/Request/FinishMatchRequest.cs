using Application.CQRS.Match.Command.Response;
using MediatR;

namespace Application.CQRS.Match.Command.Request;

public class FinishMatchRequest : IRequest<FinishBetResponse>
{
    public Guid MatchId { get; set; }

    public Guid WinnerSquadId { get; set; }
}
