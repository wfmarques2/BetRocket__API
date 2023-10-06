using Application.CQRS.Bets.Commands.Request;
using Application.CQRS.Bets.Commands.Response;
using Application.Validations;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Bets.Handlers;

public class CreateBetHandler : IRequestHandler<CreateBetRequest, CreateBetResponse>
{
    private readonly UserManager<EntityUser> _userManager;
    private readonly IBetRepository _betRepository;
    private readonly IMatchRepository _matchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBetHandler(UserManager<EntityUser> userManager, IBetRepository betRepository, IUnitOfWork unitOfWork, IMatchRepository matchRepository)
    {
        _userManager = userManager;
        _betRepository = betRepository;
        _unitOfWork = unitOfWork;
        _matchRepository = matchRepository;
    }

    public async Task<CreateBetResponse> Handle(CreateBetRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager
            .FindByIdAsync(request.UserId.ToString());

        if (user is null)
            throw new ArgumentNullException("Usuário não encontrado");
        
        var hasMoneyToBet = 
            HasEnoughMoney.HasEnoughMoneyToBet(user.Balance, request.Amount);

        user.Balance -= request.Amount;

        if(hasMoneyToBet is false)
            throw new ApplicationException("Saldo insuficiente para apostar");

        var match = 
            await _matchRepository.FindById(request.MatchId);

        if (match is null) 
            throw new ArgumentNullException("Partida não encontrada");
        

        var squadsInMatch = new List<Guid> { match.SquadOneId,  match.SquadTwoId };

        if (!squadsInMatch.Contains(request.SquadId))
            throw new ApplicationException("O time selecionado não faz parte dessa partida");
        

        await _userManager .UpdateAsync(user);

        await _betRepository.CreateAsync((ModelBet)request);

        await _unitOfWork.Commit();

        return new CreateBetResponse
        {
            Succeed = true,
        };
    }
}
