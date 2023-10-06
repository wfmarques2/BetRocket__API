using Application.CQRS.Squad.Commands.Response;
using MediatR;

namespace Application.CQRS.Squad.Commands.Request;

public class DeleteSquadByIdRequest : IRequest<DeleteSquadByIdResponse>
{
    public Guid SquadId { get; set; }
}
