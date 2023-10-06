

namespace Domain.Models;

public class ModelMatch : ModelBase
{
    public Guid SquadOneId { get; set; }

    public ModelSquad SquadOne { get; set; }

    public Guid SquadTwoId { get; set; }

    public ModelSquad SquadTwo { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public double SquadOneMultiplier { get; set; }

    public double SquadTwoMultiplier { get; set; }

    public ModelMatch() : base()
    {

    }
}
