using Application.CQRS.Users.Commands.Response;
using Infra.Entities;
using MediatR;

namespace Application.CQRS.Users.Commands.Request;

public class GrantPermissionRequest :IRequest<GrantPermissionResponse>
{
    public Guid RequestId { get; set; }

    public static implicit operator EntityAdministrativeAccessRequest(GrantPermissionRequest request)
    {
        return new EntityAdministrativeAccessRequest 
        { 
            Id = request.RequestId
        };
    }
}
