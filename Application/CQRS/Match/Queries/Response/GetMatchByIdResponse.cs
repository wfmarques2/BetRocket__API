using Domain.Models;

namespace Application.CQRS.Match.Queries.Response;

public class GetMatchByIdResponse
{
    public required ModelMatch ModelMatch { get; set; }
}
