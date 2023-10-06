using Application.CQRS.Users.Commands.Request;
using Application.CQRS.Users.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetRocket.Controllers;

[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    [HttpPost("AskForAdminAccess")]
    public async Task<IActionResult> AskForAdministrativeAccess(
    [FromServices] IMediator mediator,
    [FromBody] CreateAskForAdminAccessRequest request)
    {
        try
        {
            var adminResponse = await mediator.Send(request);
            return Ok(adminResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        };
    }

    
    [HttpPost("GrantAdminAccess")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GrantAdminAccess(
        [FromServices] IMediator mediator,
        [FromBody] GrantPermissionRequest request
        )
    {
        var permissonResponse = await mediator.Send(request);
        return Ok(permissonResponse);
    }

    [HttpGet("GetAllAskForAdminAccess")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<IActionResult> GetAllAskForAdminAccess(
        [FromServices] IMediator mediator,
        [FromQuery] GetAllAskForAccessAdminRequest request)
    {
        var accessRequests = await mediator.Send(request);

        return Ok(accessRequests);
    }

}
