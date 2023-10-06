namespace Application.Exceptions;

public class PlayerAlreadyInSquadException: Exception
{
    public PlayerAlreadyInSquadException() : base("Jogador já pertence ao time!")
    {
        
    }
}
