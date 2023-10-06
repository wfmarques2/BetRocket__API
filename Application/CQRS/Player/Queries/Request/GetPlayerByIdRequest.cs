using Application.CQRS.Player.Queries.Response;
using MediatR;

namespace Application.CQRS.Player.Queries.Request;

public class GetPlayerByIdRequest : IRequest<GetPlayerByIdResponse>
{
    public Guid PlayerId { get; set; }
}
