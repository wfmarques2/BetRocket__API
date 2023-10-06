using Application.CQRS.Player.Queries.Request;
using Application.CQRS.Player.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Player.Handlers;

public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdRequest, GetPlayerByIdResponse>
{
    private readonly IPlayerRepository _repository;

    public GetPlayerByIdHandler(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetPlayerByIdResponse> Handle(GetPlayerByIdRequest request, CancellationToken cancellationToken)
    {
        var player = await _repository.FindById(request.PlayerId);

        return new GetPlayerByIdResponse
        {
            Player = player
        };
    }
}
