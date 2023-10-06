using Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace Infra.Entities;

public class EntityGame : Entity
{

    [Required]
    public string Name { get; set; }

    [Required]
    public DateOnly Release { get; set; }

    public ICollection<EntitySquad>? Squads { get; set; }

    public EntityGame()
    {
        Squads = new List<EntitySquad>();
    }

    public static implicit operator EntityGame(ModelGame modelGame)
    {
        return new EntityGame
        {
            Id = modelGame.Id,
            Name = modelGame.Name,
            Release = modelGame.Release,
            Squads = null
        };
    }

    public static implicit operator ModelGame(EntityGame entityGame)
    {
        return new ModelGame
        {
            Id = entityGame.Id,
            Name = entityGame.Name,
            Release = entityGame.Release,
            Squads = 
            entityGame.Squads?.Select(squad => new ModelSquad
            {
                Id = squad.Id,
                SquadName = squad.SquadName,
                GameId = squad.GameId,
                Game = null,
                Players = squad.Players?.Select(players => new ModelPlayer
                {
                    Id = players.Id,
                    Name = players.Name,
                }).ToList(),
            }).ToList()
        };
    }
}