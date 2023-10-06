using Application.CQRS.Squad.Queries.Request;
using Application.CQRS.Squad.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Squad.Handlers;

internal class GetAllSquadsHandler : IRequestHandler<GetAllSquadsRequest, GetAllSquadsReponse>
{
    private readonly ISquadRepository _squadRepository;

    public GetAllSquadsHandler(ISquadRepository squadRepository)
    {
        _squadRepository = squadRepository;
    }

    public async Task<GetAllSquadsReponse> Handle(GetAllSquadsRequest request, CancellationToken cancellationToken)
    {
        var squads = await _squadRepository.FindAll();

        return new GetAllSquadsReponse 
        {
            Squads = squads
        };
    }
}
