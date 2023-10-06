using Application.CQRS.Player.Command.Response;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Player.Command.Request;

public class CreatePlayerRequest : IRequest<CreatePlayerResponse>
{
    public string Name { get; set; }

    public Guid SquadId { get; set; }

    public static implicit operator ModelPlayer(CreatePlayerRequest request)
    {
        return new ModelPlayer() 
        {
            Name = request.Name,
            SquadId = request.SquadId,
        };
    }
}
