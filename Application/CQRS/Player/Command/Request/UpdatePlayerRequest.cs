using Application.CQRS.Player.Command.Response;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Player.Command.Request;

public class UpdatePlayerRequest : IRequest<UpdatePlayerResponse>
{
    public Guid PlayerId { get; set; }

    public string Name { get; set; }

    public Guid SquadId { get; set; }

    public static implicit operator ModelPlayer(UpdatePlayerRequest request)
    {
        return new ModelPlayer()
        {
            Name = request.Name,
            SquadId = request.SquadId,
        };
    }
}
