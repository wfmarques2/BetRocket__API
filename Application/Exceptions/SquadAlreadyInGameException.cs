namespace Application.Exceptions;

public class SquadAlreadyInGameException : Exception
{
    public SquadAlreadyInGameException() : base("Essa equipe já participa desse jogo!")
    {
        
    }
}
