using Application.CQRS.Player.Queries.Response;
using MediatR;

namespace Application.CQRS.Player.Queries.Request;

public class GetAllPlayersRequest : IRequest<GetAllPlayersResponse>
{
}
