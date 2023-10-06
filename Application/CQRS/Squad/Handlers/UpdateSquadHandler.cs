using Application.CQRS.Squad.Commands.Request;
using Application.CQRS.Squad.Commands.Response;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Squad.Handlers;

public class UpdateSquadHandler : IRequestHandler<UpdateSquadRequest, UpdateSquadResponse>
{
    private readonly ISquadRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSquadHandler(ISquadRepository squadRepository, IUnitOfWork unitOfWork)
    {
        _repository = squadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateSquadResponse> Handle(UpdateSquadRequest request, CancellationToken cancellationToken)
    {
        var modelSquad = await _repository.FindById(request.SquadId);
       
        if(modelSquad is null) 
        {
            throw new ArgumentException();
        }

        modelSquad.Id = request.SquadId;
        modelSquad.SquadName = request.SquadName;
        modelSquad.GameId = request.GameId;

        var squadUpdated = await _repository.UpdateAsync(modelSquad);

        await _unitOfWork.Commit();

        return new UpdateSquadResponse
        {
            Squad = squadUpdated
        };
    }
}
