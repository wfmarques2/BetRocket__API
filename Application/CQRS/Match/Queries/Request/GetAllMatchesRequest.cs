using Application.CQRS.Match.Queries.Response;
using MediatR;

namespace Application.CQRS.Match.Queries.Request;

public class GetAllMatchesRequest : IRequest<GetAllMatchesResponse>
{
}
