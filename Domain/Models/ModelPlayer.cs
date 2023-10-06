namespace Domain.Models;

public class ModelPlayer : ModelBase
{
    public string Name { get; set; }

    public Guid SquadId { get; set; }

    public ModelSquad? Squad { get; set; }

    public ModelPlayer() : base()
    {

    }
}