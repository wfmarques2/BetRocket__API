namespace Domain.Models;

public class ModelBet : ModelBase
{
    public ModelBet() : base()
    {
        
    }

    public Guid UserId { get; set; }

    public ModelUser? User { get; set; }

    public Guid SquadId { get; set; }

    public ModelSquad? Squad { get; set; }

    public Guid MatchId { get; set; }

    public ModelMatch Match { get; set; }

    public decimal Amount { get; set; }

    public bool? Win { get; set; }

    public decimal? BetWinnings { get; set; }
}
