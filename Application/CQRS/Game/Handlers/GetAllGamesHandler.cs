using Application.CQRS.Game.Queries.Request;
using Application.CQRS.Game.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Game.Handlers;

public class GetAllGamesHandler : IRequestHandler<GetAllGamesRequest, GetAllGamesResponse>
{
    private readonly IGameRepository _repository;

    public GetAllGamesHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAllGamesResponse> Handle(GetAllGamesRequest request, CancellationToken cancellationToken)
    {
        var games = await _repository.FindAll();

        return new GetAllGamesResponse
        {
            Games = games
        };
    }
}
