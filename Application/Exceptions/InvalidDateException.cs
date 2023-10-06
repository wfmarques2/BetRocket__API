namespace Application.Exceptions;

public class InvalidDateException : Exception
{
    public InvalidDateException() : base("Data inválida!")
    {
        
    }
}
