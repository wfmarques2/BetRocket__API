using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Infra.Entities;

public class EntityPlayer : Entity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public Guid SquadId { get; set; }

    public EntitySquad? Squad { get; set; }

    public EntityPlayer()
    {

    }

    public static implicit operator EntityPlayer(ModelPlayer modelPlayer)
    {
        return new EntityPlayer
        {
            Id = modelPlayer.Id,
            Name = modelPlayer.Name,
            SquadId = modelPlayer.SquadId,
            Squad = modelPlayer.Squad is null 
            ? null 
            : (EntitySquad)modelPlayer.Squad
        };
    }

    public static implicit operator ModelPlayer(EntityPlayer entityPlayer)
    {
        return new ModelPlayer
        {
            Id = entityPlayer.Id,
            Name = entityPlayer.Name,
            SquadId = entityPlayer.SquadId,
            Squad = entityPlayer.Squad is null
            ? null
            : new ModelSquad
            {
                Game = null,
                GameId = entityPlayer.Squad.GameId,
                SquadName = entityPlayer.Squad.SquadName
            }
        };
    }
}
