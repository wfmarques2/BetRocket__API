using Application.CQRS.Squad.Commands.Request;
using Application.CQRS.Squad.Commands.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.CQRS.Squad.Handlers;

public class CreateSquadHandler : IRequestHandler<CreateSquadRequest, CreateSquadResponse>
{
    private readonly ISquadRepository _squadRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateSquadHandler(ISquadRepository squadRepository, IUnitOfWork unitOfWork)
    {
        _squadRepository = squadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateSquadResponse> Handle(CreateSquadRequest request, CancellationToken cancellationToken)
    {
        var modelSquad = (ModelSquad)request;

        await _squadRepository.CreateAsync(modelSquad);

        await _unitOfWork.Commit();

        return new CreateSquadResponse
        {
            SquadName = modelSquad.SquadName
        };
    }
}
