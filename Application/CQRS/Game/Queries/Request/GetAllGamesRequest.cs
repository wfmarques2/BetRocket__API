using Application.CQRS.Game.Queries.Response;
using MediatR;

namespace Application.CQRS.Game.Queries.Request;

public class GetAllGamesRequest : IRequest<GetAllGamesResponse>
{
}
