using Application.CQRS.Game.Commands.Request;
using Application.CQRS.Game.Commands.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Game.Handlers;

public class CreateGameHandler : IRequestHandler<CreateGameRequest, CreateGameResponse>
{
    private readonly IGameRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGameHandler(IGameRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
    {
        var modelGame = (ModelGame)request;

        await _repository.CreateAsync(modelGame);

        await _unitOfWork.Commit();

        return new CreateGameResponse
        {
            Game = modelGame,
        };
    }
}
