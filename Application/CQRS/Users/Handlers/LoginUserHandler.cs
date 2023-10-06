using Application.CQRS.Users.Commands.Request;
using Application.CQRS.Users.Commands.Response;
using Domain.Interfaces.Services;
using Infra.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Users.Handlers;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly SignInManager<EntityUser> _signInManager;
    private readonly ITokenService<EntityUser> _tokenService;

    public LoginUserHandler(SignInManager<EntityUser> signInManager, ITokenService<EntityUser> tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _signInManager
            .PasswordSignInAsync(request.Username,
            request.Password, false, false);

        if (!result.Succeeded)
            throw new Exception("Usuário não autenticado");

        var user = _signInManager
            .UserManager
            .Users.FirstOrDefault(user => user.NormalizedUserName == 
            request.Username.ToUpper());

        var token = _tokenService.GenerateToken(user);

        return (LoginUserResponse)token;
    }
}
