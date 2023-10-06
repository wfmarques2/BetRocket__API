using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Infra.Entities;

public class EntitySquad : Entity
{
    [Required]
    public string SquadName { get; set; }

    [Required]
    public Guid GameId { get; set; }

    public EntityGame? Game { get; set; }

    public ICollection<EntityPlayer>? Players { get; set; }

    public ICollection<EntityBet>? Bets { get; set; }

    public EntitySquad()
    {
        Players = new List<EntityPlayer>();
        Bets = new List<EntityBet>();
    }

    public static implicit operator EntitySquad(ModelSquad modelSquad)
    {
        return new EntitySquad
        {
            Id = modelSquad.Id,
            SquadName = modelSquad.SquadName,
            GameId = modelSquad.GameId,
            Game = modelSquad.Game is null
            ? null
            : (EntityGame)modelSquad.Game,
            Players = modelSquad.Players?.Select(
                player => (EntityPlayer)player
            ).ToList()
        };
    }

    public static implicit operator ModelSquad(EntitySquad entitySquad)
    {
        return new ModelSquad
        {
            Id = entitySquad.Id,
            SquadName = entitySquad.SquadName,
            GameId = entitySquad.GameId,
            Game = entitySquad.Game is null
            ? null
            : (ModelGame)entitySquad.Game,

            Players = entitySquad.Players?.Select
                (player => (ModelPlayer)player).ToList()
        };
    }
}
