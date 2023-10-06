using Application.CQRS.Game.Commands.Request;
using Application.CQRS.Game.Commands.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Game.Handlers;

public class DeleteGameByIdHandler : IRequestHandler<DeleteGameByIdRequest, DeleteGameByIdResponse>
{
    private readonly IGameRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGameByIdHandler(IGameRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteGameByIdResponse> Handle(DeleteGameByIdRequest request, CancellationToken cancellationToken)
    {
        var game = await _repository.FindById(request.GameId);

        await _repository.Delete(game);

        await _unitOfWork.Commit();

        return new DeleteGameByIdResponse
        {
            Success = true
        };
    }
}
