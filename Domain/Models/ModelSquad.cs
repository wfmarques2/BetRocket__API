namespace Domain.Models;

public class ModelSquad : ModelBase
{
    public string SquadName { get; set; }

    public ICollection<ModelPlayer>? Players { get; set; }

    public Guid GameId { get; set; }

    public ModelGame? Game { get; set; }

    public ICollection<ModelBet> Bets { get; set; }

    public ModelSquad() : base()
    {
        Bets = new List<ModelBet>();
        Players = new List<ModelPlayer>();
        //verificar se n quebrou
    }
}
