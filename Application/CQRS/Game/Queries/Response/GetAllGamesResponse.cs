using Domain.Models;

namespace Application.CQRS.Game.Queries.Response;

public class GetAllGamesResponse
{
    public required ICollection<ModelGame> Games { get; set; }
}
