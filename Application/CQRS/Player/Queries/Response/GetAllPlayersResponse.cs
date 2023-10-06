using Domain.Models;

namespace Application.CQRS.Player.Queries.Response;

public class GetAllPlayersResponse
{
    public ICollection<ModelPlayer> Players { get; set; }
}
