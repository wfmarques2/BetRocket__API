using Domain.Models;

namespace Application.CQRS.Game.Commands.Response;

public class CreateGameResponse
{
    public ModelGame Game { get; set; }
}
