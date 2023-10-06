using Application.CQRS.Squad.Queries.Request;
using Application.CQRS.Squad.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Squad.Handlers;

public class GetSquadByIdHandler : IRequestHandler<GetSquadByIdRequest, GetSquadByIdResponse>
{
    private readonly ISquadRepository _repository;

    public GetSquadByIdHandler(ISquadRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetSquadByIdResponse> Handle(GetSquadByIdRequest request, CancellationToken cancellationToken)
    {
        var squad = await _repository.FindById(request.SquadId);

        return new GetSquadByIdResponse
        {
            Squad = squad
        };
    }
}
