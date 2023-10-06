using Domain.Models;

namespace Application.CQRS.Player.Command.Response;

public class UpdatePlayerResponse
{
    public ModelPlayer? Player { get; set; }
}
