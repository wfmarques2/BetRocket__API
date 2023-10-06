using Application.CQRS.Match.Command.Response;
using MediatR;

namespace Application.CQRS.Match.Command.Request;

public class DeleteMatchByIdRequest :IRequest<DeleteMatchByIdResponse>
{
    public Guid MatchId { get; set; }
}
