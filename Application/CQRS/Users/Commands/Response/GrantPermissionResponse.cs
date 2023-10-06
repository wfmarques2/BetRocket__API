namespace Application.CQRS.Users.Commands.Response;

public class GrantPermissionResponse
{
    public bool Succeed { get; set; }

    public GrantPermissionResponse()
    {
        Succeed = true;
    }
}
