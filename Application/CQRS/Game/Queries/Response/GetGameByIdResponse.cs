using Domain.Models;

namespace Application.CQRS.Game.Queries.Response;

public class GetGameByIdResponse
{
    public ModelGame Game { get; set; }
}
