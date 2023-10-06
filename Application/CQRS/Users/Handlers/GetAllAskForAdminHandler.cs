using Application.CQRS.Users.Queries.Request;
using Application.CQRS.Users.Queries.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class GetAllAskForAdminHandler : IRequestHandler<GetAllAskForAccessAdminRequest, GetAllAskForAdminAccessResponse>
{
    private readonly AccessRequestRepository _requestRepository;

    public GetAllAskForAdminHandler(AccessRequestRepository requestRepository, IUnitOfWork unitOfWork)
    {
        _requestRepository = requestRepository;
    }

    public async Task<GetAllAskForAdminAccessResponse> Handle(GetAllAskForAccessAdminRequest request, CancellationToken cancellationToken)
    {
        var accessRequests = await _requestRepository.GetAllAccessRequestsAsync();

        return new GetAllAskForAdminAccessResponse
        {
            AdminAccessRequests = accessRequests
        };
    }
}
