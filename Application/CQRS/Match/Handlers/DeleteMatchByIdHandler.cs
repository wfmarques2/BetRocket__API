using Application.CQRS.Match.Command.Request;
using Application.CQRS.Match.Command.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Match.Handlers;

public class DeleteMatchByIdHandler : IRequestHandler<DeleteMatchByIdRequest, DeleteMatchByIdResponse>
{
    private readonly IMatchRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMatchByIdHandler(IMatchRepository matchRepository, IUnitOfWork unitOfWork)
    {
        _repository = matchRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteMatchByIdResponse> Handle(DeleteMatchByIdRequest request, CancellationToken cancellationToken)
    {
        var modelMatch = await _repository.FindById(request.MatchId);

        if (modelMatch is null)
        {
            throw new ArgumentException("Partida não encontrada");
        }

        await _repository.Delete(modelMatch);

        await _unitOfWork.Commit();

        return new DeleteMatchByIdResponse
        {
            Succeed = true
        };
    }
}
