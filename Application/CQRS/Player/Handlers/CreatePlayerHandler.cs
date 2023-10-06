using Application.CQRS.Player.Command.Request;
using Application.CQRS.Player.Command.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Player.Handlers;

public class CreatePlayerHandler : IRequestHandler<CreatePlayerRequest, CreatePlayerResponse>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlayerHandler(IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
    {
        _playerRepository = playerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatePlayerResponse> Handle(CreatePlayerRequest request, CancellationToken cancellationToken)
    {
        var modelPlayer = (ModelPlayer)request;

        await _playerRepository.CreateAsync(modelPlayer);

        await _unitOfWork.Commit();

        return new CreatePlayerResponse 
        {
            Name = modelPlayer.Name
        };
    }
}
