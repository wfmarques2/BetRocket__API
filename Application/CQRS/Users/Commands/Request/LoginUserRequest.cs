using Application.CQRS.Users.Commands.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Users.Commands.Request;

public class LoginUserRequest : IRequest<LoginUserResponse>
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
