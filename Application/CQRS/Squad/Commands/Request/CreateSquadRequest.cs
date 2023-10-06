using Application.CQRS.Squad.Commands.Response;
using Domain.Models;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.CQRS.Squad.Commands.Request;

public class CreateSquadRequest : IRequest<CreateSquadResponse>
{
    public string SquadName { get; set; }

    public Guid GameId { get; set; }

    public static implicit operator ModelSquad(CreateSquadRequest request)
    {
        return new ModelSquad 
        {
            SquadName = request.SquadName,
            GameId = request.GameId,
        };
    }
}
