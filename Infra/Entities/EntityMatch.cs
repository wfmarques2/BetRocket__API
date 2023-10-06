using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Infra.Entities;

public class EntityMatch : Entity
{
    [Required]
    public Guid SquadOneId { get; set; }

    public EntitySquad SquadOne { get; set; }

    [Required]
    public Guid SquadTwoId { get; set; }

    public EntitySquad SquadTwo { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    [Required]
    public double SquadOneMultiplier { get; set; }

    [Required]
    public double SquadTwoMultiplier { get; set; }

    public EntityMatch()
    {
        
    }

    public static implicit operator EntityMatch(ModelMatch modelMatch)
    {
        return new EntityMatch
        {
            Id = modelMatch.Id,
            SquadOneId = modelMatch.SquadOneId,
            SquadOne = modelMatch.SquadOne is null
            ? null
            : (EntitySquad)modelMatch.SquadOne,

            SquadTwoId = modelMatch.SquadTwoId,
            SquadTwo = modelMatch.SquadTwo is null
            ? null
            : (EntitySquad)modelMatch.SquadTwo,

            StartTime = modelMatch.StartTime,
            EndTime = modelMatch.EndTime,
            SquadOneMultiplier = modelMatch.SquadOneMultiplier,
            SquadTwoMultiplier = modelMatch.SquadTwoMultiplier,
        };
    }

    public static implicit operator ModelMatch(EntityMatch entityMatch)
    {
        return new ModelMatch
        {
            Id = entityMatch.Id,
            SquadOneId = entityMatch.SquadOneId,
            SquadOne = entityMatch.SquadOne,
            SquadTwoId = entityMatch.SquadTwoId,
            SquadTwo = entityMatch.SquadTwo,
            StartTime = entityMatch.StartTime,
            EndTime = entityMatch.EndTime,
            SquadOneMultiplier = entityMatch.SquadOneMultiplier,
            SquadTwoMultiplier = entityMatch.SquadTwoMultiplier,
        };
    }
}
