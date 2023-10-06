using Application.CQRS.Game.Commands.Response;
using MediatR;

namespace Application.CQRS.Game.Commands.Request;

public class UpdateGameRequest : IRequest<UpdateGameResponse>
{
    public required Guid GameId { get; set; }

    public required string Name { get; set; }
}
