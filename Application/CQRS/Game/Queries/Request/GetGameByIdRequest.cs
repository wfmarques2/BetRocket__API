using Application.CQRS.Game.Queries.Response;
using MediatR;

namespace Application.CQRS.Game.Queries.Request;

public class GetGameByIdRequest : IRequest<GetGameByIdResponse>
{
    public Guid GameId { get; set; }
}
