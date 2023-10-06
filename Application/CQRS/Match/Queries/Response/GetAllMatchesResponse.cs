using Domain.Models;

namespace Application.CQRS.Match.Queries.Response;

public class GetAllMatchesResponse
{
    public required ICollection<ModelMatch> Matches { get; set; }
}
