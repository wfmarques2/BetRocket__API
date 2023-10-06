using Application.CQRS.Player.Command.Response;
using MediatR;

namespace Application.CQRS.Player.Command.Request;

public class DeletePlayerByIdRequest : IRequest<DeletePlayerByIdResponse>
{
    public Guid PlayerId { get; set; }
}
