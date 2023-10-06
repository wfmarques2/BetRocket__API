using Application.CQRS.Users.Commands.Request;
using Application.CQRS.Users.Commands.Response;
using Domain.Models;
using Infra.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Users.Handler;

public class CreateUserHandler :
    IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private UserManager<EntityUser> _userManager;

    public CreateUserHandler(UserManager<EntityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        ModelUser modelUser =  (ModelUser)request;

        EntityUser user = (EntityUser)modelUser;

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new ApplicationException("Não foi possível cadastrar usuário!");

        return (CreateUserResponse)modelUser;
    }
}
