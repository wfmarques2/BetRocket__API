using Application.CQRS.Match.Command.Response;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Match.Command.Request;

public class CreateMatchRequest : IRequest<CreateMatchResponse>
{
    public  Guid SquadOneId { get; set; }

    public  Guid SquadTwoId { get; set; }

    public DateTime StartTime { get; set; }

    public  double SquadOneMultiplier { get; set; }

    public  double SquadTwoMultiplier { get; set; }

    public static implicit operator ModelMatch(CreateMatchRequest request)
    {
        return new ModelMatch
        {
            SquadOneId = request.SquadOneId,
            SquadTwoId = request.SquadTwoId,
            StartTime = request.StartTime,
            SquadOneMultiplier = request.SquadOneMultiplier,
            SquadTwoMultiplier = request.SquadTwoMultiplier,
        };
    }
}
