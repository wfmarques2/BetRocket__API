using Application.CQRS.Match.Command.Response;
using MediatR;

namespace Application.CQRS.Match.Command.Request;

public class UpdateMatchRequest : IRequest<UpdateMatchResponse>
{
    public Guid MatchId { get; set; }

    public DateTime StartTime { get; set; }

    public double SquadOneMultiplier { get; set; }

    public double SquadTwoMultiplier { get; set; }
}
