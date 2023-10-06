using Domain.Models;

namespace Application.CQRS.Match.Command.Response;

public class UpdateMatchResponse
{
    public required ModelMatch Match { get; set; }
}
