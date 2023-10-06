using Application.CQRS.Squad.Queries.Response;
using MediatR;

namespace Application.CQRS.Squad.Queries.Request;

public class GetAllSquadsRequest : IRequest<GetAllSquadsReponse>
{
}
