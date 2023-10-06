namespace Application.CQRS.Users.Commands.Response;

public class LoginUserResponse
{
    public string Token { get; set; }

    public static implicit operator LoginUserResponse(string token)
    {
        return new LoginUserResponse
        {
            Token = token
        };
    }
}





