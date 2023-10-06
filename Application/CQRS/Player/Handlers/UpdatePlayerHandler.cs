using Application.CQRS.Player.Command.Request;
using Application.CQRS.Player.Command.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Player.Handlers;

public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerRequest, UpdatePlayerResponse>
{
    private readonly IPlayerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlayerHandler(IPlayerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdatePlayerResponse> Handle(UpdatePlayerRequest request, CancellationToken cancellationToken)
    {
        var modelPlayer = await _repository.FindById(request.PlayerId);

        if(modelPlayer is null)
        {
            throw new ArgumentException();
        }

        modelPlayer.Id = request.PlayerId;
        modelPlayer.Name = request.Name;
        modelPlayer.SquadId = request.SquadId;

        var playerUpdated = await _repository.UpdateAsync(modelPlayer);

        await _unitOfWork.Commit();

        return new UpdatePlayerResponse
        {
            Player = playerUpdated
        };
    }
}
