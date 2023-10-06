using Application.CQRS.Match.Command.Request;
using Application.CQRS.Match.Command.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Match.Handlers;

public class UpdateMatchHandler : IRequestHandler<UpdateMatchRequest, UpdateMatchResponse>
{
    private readonly IMatchRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMatchHandler(IMatchRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateMatchResponse> Handle(UpdateMatchRequest request, CancellationToken cancellationToken)
    {
        var modelMatch = await _repository.FindById(request.MatchId);

        if (modelMatch is null)
        {
            throw new ApplicationException("Partida não encontrada");
        }

        modelMatch.Id = request.MatchId;
        modelMatch.StartTime = request.StartTime;
        modelMatch.SquadOneMultiplier = request.SquadOneMultiplier;
        modelMatch.SquadTwoMultiplier = request.SquadTwoMultiplier;

        await _repository.UpdateAsync(modelMatch);

        await _unitOfWork.Commit();

        return new UpdateMatchResponse
        {
            Match = modelMatch
        };
    }
}
