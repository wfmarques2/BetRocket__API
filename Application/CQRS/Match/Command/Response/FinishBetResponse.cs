namespace Application.CQRS.Match.Command.Response;

public class FinishBetResponse
{
    public int TotalWinners { get; set; }

    public int TotalLosers { get; set; }

    public decimal AmountBet { get; set; }
 }
