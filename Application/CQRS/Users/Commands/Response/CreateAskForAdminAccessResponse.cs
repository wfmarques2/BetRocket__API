using MediatR;

namespace Application.CQRS.Users.Commands.Response;

public class CreateAskForAdminAccessResponse 
{
    public bool Sent { get; set; }

    public CreateAskForAdminAccessResponse()
    {
        Sent = true;
    }

}
