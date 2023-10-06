namespace Application.CQRS.Player.Command.Response;

public class CreatePlayerResponse
{
    public string Name { get; set; }

    public bool Succeed { get; set; }

    public CreatePlayerResponse()
    {
        Succeed = true;
    }
}
