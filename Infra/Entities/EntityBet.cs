using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Infra.Entities;

public class EntityBet : Entity
{
    [Required]
    public string UserId { get; set; }

    public EntityUser? User { get; set; }

    [Required]
    public Guid SquadId { get; set; }

    public EntitySquad? Squad { get; set; }

    [Required]
    public Guid MatchId { get; set; }

    public EntityMatch? Match { get; set; }

    [Required]
    public decimal Amount { get; set; }

    public bool? Win { get; set; }

    public decimal? BetWinnings { get; set; }

    public EntityBet()
    {

    }

    public static implicit operator EntityBet(ModelBet modelBet)
    {
        return new EntityBet
        {
            UserId = modelBet.UserId.ToString(),
            User = null,
            SquadId = modelBet.SquadId,
            Squad = null,
            MatchId = modelBet.MatchId,
            Match = null,
            Amount = modelBet.Amount,
            Win = modelBet.Win,
        };
    }

    public static implicit operator ModelBet(EntityBet entityBet)
    {
        return new ModelBet
        {
            UserId = Guid.Parse(entityBet.UserId),
            User = entityBet.User is null
            ? null
            : (ModelUser)entityBet.User,

            SquadId = entityBet.SquadId,
            Squad = entityBet.Squad is null
            ? null
            : (ModelSquad)entityBet.Squad,

            MatchId = entityBet.MatchId,
            Match = entityBet.Match is null
            ? null
            : (ModelMatch)entityBet.Match,

            Amount = entityBet.Amount,
            Win = entityBet.Win,
        };
    }
}
