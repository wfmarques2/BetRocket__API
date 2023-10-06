using Application.CQRS.Match.Queries.Response;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Match.Queries.Request;

public class GetMatchByIdRequest : IRequest<GetMatchByIdResponse>
{
    public Guid MatchId { get; set; }
}
