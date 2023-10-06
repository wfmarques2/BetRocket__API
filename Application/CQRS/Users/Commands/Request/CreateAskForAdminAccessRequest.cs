using Application.CQRS.Users.Commands.Response;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Users.Commands.Request;

public class CreateAskForAdminAccessRequest : CreateRequest, IRequest<CreateAskForAdminAccessResponse>
{
    public CreateAskForAdminAccessRequest()
    {
    }

    public static implicit operator ModelAskForAdminAccess(CreateAskForAdminAccessRequest request)
    {
        return new ModelAskForAdminAccess
            (
            username: request.Username,
            birthDate: request.BirthDate,
            password: request.Password.ToString()
            );
    }
}
