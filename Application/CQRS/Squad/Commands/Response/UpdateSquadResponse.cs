using Domain.Models;

namespace Application.CQRS.Squad.Commands.Response;

public class UpdateSquadResponse
{
    public ModelSquad? Squad { get; set; }
}
