using Application.CQRS.Game.Commands.Response;
using MediatR;

namespace Application.CQRS.Game.Commands.Request;

public class DeleteGameByIdRequest : IRequest<DeleteGameByIdResponse>
{
    public Guid GameId { get; set; }
}
