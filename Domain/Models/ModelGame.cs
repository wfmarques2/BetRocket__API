using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class ModelGame : ModelBase
{
    public string Name { get; set; }

    public DateOnly Release { get; set; }

    public ICollection<ModelSquad>? Squads { get; set; } 

    public ModelGame() : base()
    {
        Squads = new List<ModelSquad>();
    }
}