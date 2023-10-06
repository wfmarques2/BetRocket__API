using Application.CQRS.Match.Command.Request;
using Application.CQRS.Match.Command.Response;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Match.Handlers;

public class CreateMatchHandler : IRequestHandler<CreateMatchRequest, CreateMatchResponse>
{
    private readonly IMatchRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMatchHandler(IMatchRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateMatchResponse> Handle(CreateMatchRequest request, CancellationToken cancellationToken)
    {
        var modelMatch = (ModelMatch)request;

        await _repository.CreateAsync(modelMatch);

        await _unitOfWork.Commit();

        return new CreateMatchResponse
        {
            Match = modelMatch,
        };
    }
}
