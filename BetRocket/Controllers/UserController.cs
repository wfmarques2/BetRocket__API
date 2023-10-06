using Application.CQRS.Users.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetRocket.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser(
        [FromServices] IMediator mediator,
        [FromBody] CreateUserRequest request)
    {
        var user = await mediator.Send(request);
        return Ok(user);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(
        [FromServices] IMediator mediator,
        [FromBody] LoginUserRequest request)
    {
        var token = await mediator.Send(request);
        return Ok(token);
    }
}
