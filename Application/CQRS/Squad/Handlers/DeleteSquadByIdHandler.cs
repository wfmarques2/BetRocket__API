using Application.CQRS.Squad.Commands.Request;
using Application.CQRS.Squad.Commands.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Squad.Handlers;

public class DeleteSquadByIdHandler : IRequestHandler<DeleteSquadByIdRequest, DeleteSquadByIdResponse>
{
    private readonly ISquadRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSquadByIdHandler(ISquadRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteSquadByIdResponse> Handle(DeleteSquadByIdRequest request, CancellationToken cancellationToken)
    {
        var squad = await _repository.FindById(request.SquadId);
        
        if (squad is null)
        {
            //Criar exception personalizada
            throw new ArgumentException();
        }

        await _repository.Delete(squad);

        await _unitOfWork.Commit();

        return new DeleteSquadByIdResponse();
    }
}
