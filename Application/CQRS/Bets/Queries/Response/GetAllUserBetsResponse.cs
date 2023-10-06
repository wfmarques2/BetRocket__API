using Domain.Models;

namespace Application.CQRS.Bets.Queries.Response;

public class GetAllUserBetsResponse
{
    public ICollection<ModelBet> Bets { get; set; }
}
