using Application.CQRS.Users.Commands.Request;
using Application.CQRS.Users.Commands.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class CreateAskForAdminHandler : IRequestHandler<CreateAskForAdminAccessRequest, CreateAskForAdminAccessResponse>
{
    private readonly AccessRequestRepository _requestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAskForAdminHandler(AccessRequestRepository requestRepository, IUnitOfWork unitOfWork)
    {
        _requestRepository = requestRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateAskForAdminAccessResponse> Handle(CreateAskForAdminAccessRequest request, CancellationToken cancellationToken)
    {
        await _requestRepository.CreateAsync(request);

        await _unitOfWork.Commit();

        return new CreateAskForAdminAccessResponse();
    }
}
