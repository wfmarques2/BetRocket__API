using Application.CQRS.Users.Queries.Response;
using MediatR;

namespace Application.CQRS.Users.Queries.Request;

public class GetAllAskForAccessAdminRequest : IRequest<GetAllAskForAdminAccessResponse>
{
}
