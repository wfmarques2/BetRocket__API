using Application.CQRS.Game.Queries.Request;
using Application.CQRS.Game.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Game.Handlers;

public class GetGameByIdHandler : IRequestHandler<GetGameByIdRequest, GetGameByIdResponse>
{
    private readonly IGameRepository _repository;

    public GetGameByIdHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetGameByIdResponse> Handle(GetGameByIdRequest request, CancellationToken cancellationToken)
    {
        var game = await _repository.FindById(request.GameId);

        return new GetGameByIdResponse
        {
            Game = game
        };
    }
}
