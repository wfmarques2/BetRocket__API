using Domain.Models;

namespace Application.CQRS.Player.Queries.Response;

public class GetPlayerByIdResponse
{
    public ModelPlayer Player { get; set; }
}
