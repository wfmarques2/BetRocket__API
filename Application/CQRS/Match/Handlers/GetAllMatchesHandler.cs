using Application.CQRS.Game.Queries.Response;
using Application.CQRS.Match.Queries.Request;
using Application.CQRS.Match.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Match.Handlers;

public class GetAllMatchesHandler : IRequestHandler<GetAllMatchesRequest, GetAllMatchesResponse>
{
    private readonly IMatchRepository _repository;

    public GetAllMatchesHandler(IMatchRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAllMatchesResponse> Handle(GetAllMatchesRequest request, CancellationToken cancellationToken)
    {
        var matches = await _repository.FindAll();

        return new GetAllMatchesResponse 
        {
            Matches = matches 
        };
    }
}
