using Application.CQRS.Match.Command.Request;
using Application.CQRS.Match.Command.Response;
using Domain.Interfaces.Repositories;
using Infra.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Xml;

namespace Application.CQRS.Match.Handlers;

public class FinishMatchHandler : IRequestHandler<FinishMatchRequest, FinishBetResponse>
{
    private readonly IMatchRepository _matchRepository;
    private readonly IBetRepository _betRepository;
    private readonly UserManager<EntityUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public FinishMatchHandler(IMatchRepository matchRepository, IBetRepository betRepository, UserManager<EntityUser> userManager, IUnitOfWork unitOfWork)
    {
        _matchRepository = matchRepository;
        _betRepository = betRepository;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<FinishBetResponse> Handle(FinishMatchRequest request, CancellationToken cancellationToken)
    {
        decimal amountBet = 0;

        var modelMatch = await _matchRepository.FindById(request.MatchId);

        if (modelMatch.EndTime is not null)
            throw new ApplicationException("Essa partida já foi finalizada");
        
        if (modelMatch is null)
            throw new ApplicationException("Partida não encontrada");

        var squadsInMatch = new List<Guid> { modelMatch.SquadOneId, modelMatch.SquadTwoId };

        if (!squadsInMatch.Contains(request.WinnerSquadId))
            throw new ApplicationException("O time selecionado não faz parte dessa partida");

        var bets = await _betRepository.FindAllInMatch(request.MatchId);

        foreach (var bet in bets)
        {
            var win = bet.SquadId == request.WinnerSquadId;

            double teamMultiplier = bet.SquadId == modelMatch.SquadOneId
                ? modelMatch.SquadOneMultiplier
                : modelMatch.SquadTwoMultiplier;

            decimal betWinnings = win
                ? (decimal)((double)bet.Amount * teamMultiplier)
                : 0;

            amountBet += bet.Amount;

            bet.Win = win;
            bet.BetWinnings = betWinnings;

            if (win)
            {
                var user = await _userManager
                    .FindByIdAsync(bet.UserId.ToString());

                if (user is not null)
                {
                    user.Balance += betWinnings;
                    await _userManager.UpdateAsync(user);
                }
            }
            await _betRepository.UpdateAsync(bet);
        }

        modelMatch.EndTime = modelMatch.StartTime.AddHours(3);

        await _matchRepository.UpdateAsync(modelMatch);

        await _unitOfWork.Commit();

        return new FinishBetResponse
        {
            AmountBet = amountBet,
        };
    }
}
