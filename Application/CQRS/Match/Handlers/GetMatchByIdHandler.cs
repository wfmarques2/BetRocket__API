using Application.CQRS.Match.Queries.Request;
using Application.CQRS.Match.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.CQRS.Match.Handlers;

public class GetMatchByIdHandler : IRequestHandler<GetMatchByIdRequest, GetMatchByIdResponse>
{
    private readonly IMatchRepository _repository;

    public GetMatchByIdHandler(IMatchRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetMatchByIdResponse> Handle(GetMatchByIdRequest request, CancellationToken cancellationToken)
    {
        var match = await _repository.FindById(request.MatchId);

        if (match is null) 
        {
            throw new ArgumentException("Partida não encontrada");
        }

        return new GetMatchByIdResponse
        {
            ModelMatch = match,
        };
    }
}

