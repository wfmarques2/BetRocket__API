using Domain.Models;
using Infra.Entities;

namespace Application.CQRS.Squad.Queries.Response;

public class GetAllSquadsReponse
{
    public ICollection<ModelSquad> Squads { get; set; }
}
