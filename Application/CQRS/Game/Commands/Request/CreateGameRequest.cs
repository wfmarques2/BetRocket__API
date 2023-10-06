using Application.CQRS.Game.Commands.Response;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Game.Commands.Request;

public class CreateGameRequest : IRequest<CreateGameResponse>
{
    public string Name { get; set; }

    public DateOnly Release { get; set; }

    public static implicit operator ModelGame(CreateGameRequest request)
    {
        return new ModelGame
        {
            Name = request.Name,
            Release = request.Release
        };
    }
}
