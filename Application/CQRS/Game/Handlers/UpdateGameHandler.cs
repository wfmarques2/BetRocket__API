using Application.CQRS.Game.Commands.Request;
using Application.CQRS.Game.Commands.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Game.Handlers;

public class UpdateGameHandler : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
{
    private readonly IGameRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGameHandler(IGameRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
    {
        var modelGame = await _repository.FindById(request.GameId);

        if (modelGame is null)
        {
            //Criar exception personalizada
            throw new ApplicationException();
        }

        modelGame.Id = request.GameId;
        modelGame.Name = request.Name;

        var gameUpdated = await _repository.UpdateAsync(modelGame);

        await _unitOfWork.Commit();

        return new UpdateGameResponse 
        { 
            Game = gameUpdated
        };
    }
}
