using Application.CQRS.Users.Commands.Request;
using Application.CQRS.Users.Commands.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Entities;
using Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Application.CQRS.Users.Handlers;

public class GrantPermissionHandler : IRequestHandler<GrantPermissionRequest, GrantPermissionResponse>
{
    private readonly AccessRequestRepository _requestRepository;
    private readonly UserManager<EntityUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public GrantPermissionHandler(AccessRequestRepository requestRepository, UserManager<EntityUser> userManager, IUnitOfWork unitOfWork)
    {
        _requestRepository = requestRepository;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<GrantPermissionResponse> Handle(GrantPermissionRequest permissionRequest, CancellationToken cancellationToken)
    {
        var accessRequest = (EntityAdministrativeAccessRequest)permissionRequest;

        var request = await _requestRepository.FindAccessRequestByIdAsync(accessRequest);

        var modelUser = (ModelUser)request;

        modelUser.SetAdminUser();

        var user = (EntityUser)modelUser;

        var result = await _userManager.CreateAsync(user, modelUser.Password);

        if (!result.Succeeded)
            throw new ApplicationException("Não foi possível cadastrar usuário!");

        await _requestRepository.Delete(accessRequest);

        await _unitOfWork.Commit();

        return new GrantPermissionResponse();
    }
}

