using Application.CQRS.Bets.Queries.Request;
using Application.CQRS.Bets.Queries.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Bets.Handlers;

public class GetAllUserBetsHandler : IRequestHandler<GetAllUserBetsRequest, GetAllUserBetsResponse>
{
    private readonly IBetRepository _repository;

    public GetAllUserBetsHandler(IBetRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAllUserBetsResponse> Handle(GetAllUserBetsRequest request, CancellationToken cancellationToken)
    {
        var bets = await _repository.FindAllInMatch(request.UserId);

        return new GetAllUserBetsResponse
        {
            Bets = bets
        };
    }
}
