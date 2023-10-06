using Domain.Models;

namespace Application.CQRS.Squad.Queries.Response;

public class GetSquadByIdResponse
{
    public ModelSquad Squad { get; set; }
}
