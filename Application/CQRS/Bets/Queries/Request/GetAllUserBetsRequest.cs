using Application.CQRS.Bets.Queries.Response;
using MediatR;

namespace Application.CQRS.Bets.Queries.Request;

public class GetAllUserBetsRequest : IRequest<GetAllUserBetsResponse>
{
    public Guid UserId { get; set; }
}
