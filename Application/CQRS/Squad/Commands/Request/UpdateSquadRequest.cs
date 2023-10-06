using Application.CQRS.Squad.Commands.Response;
using MediatR;

namespace Application.CQRS.Squad.Commands.Request;

public class UpdateSquadRequest : IRequest<UpdateSquadResponse>
{
    public Guid SquadId { get; set; }

    public string SquadName { get; set;}

    public Guid GameId { get; set;}
}
