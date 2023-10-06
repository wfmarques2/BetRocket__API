using Domain.Models;

namespace Application.CQRS.Match.Command.Response;

public class CreateMatchResponse
{
    public required ModelMatch Match { get; set; }
}
