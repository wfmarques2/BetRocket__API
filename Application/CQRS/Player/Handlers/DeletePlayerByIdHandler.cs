using Application.CQRS.Player.Command.Request;
using Application.CQRS.Player.Command.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Player.Handlers;

public class DeletePlayerByIdHandler : IRequestHandler<DeletePlayerByIdRequest, DeletePlayerByIdResponse>
{
    private readonly IPlayerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePlayerByIdHandler(IPlayerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeletePlayerByIdResponse> Handle(DeletePlayerByIdRequest request, CancellationToken cancellationToken)
    {
        var player = await _repository.FindById(request.PlayerId);

        if (player is null) 
        {
            //criar exception personalizada
            throw new Exception();
        }

        await _repository.Delete(player);

        await _unitOfWork.Commit();

        return new DeletePlayerByIdResponse();
    }
}
