using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BetRocket.Controllers.Bet.Dtos;

public class CreateBetDto
{
    public Guid MatchId { get; set; }
    public Guid SelectedSquadId { get; set; }

    public decimal Amount { get; set; }
}
