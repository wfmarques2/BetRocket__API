using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Context;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class BetRepository : IBetRepository
{
    private readonly BetContext _context;

    public BetRepository(BetContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ModelBet modelBet)
    {
        var entityBet = (EntityBet)modelBet;

        await _context.Bets.AddAsync(entityBet);
    }

    public Task Delete(ModelBet modelBet)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<ModelBet>> FindAll(Guid userId)
    {
        var bets = await
             _context
             .Bets
             .Where(bet => bet.UserId == userId.ToString())
             .AsNoTracking()
             .ToArrayAsync();

        var modelBets = bets.Select(bet => ((ModelBet)bet)).ToArray();

        return modelBets;
    }

    public async Task<ICollection<ModelBet>> FindAllInMatch(Guid matchId)
    {
        var entityBets = await
            _context
            .Bets
            .Where(bet => bet.MatchId == matchId)
            .AsNoTracking()
            .ToArrayAsync();

        var modelBets = entityBets.Select(bet => (ModelBet)bet).ToList();

        return modelBets;
    }

    public async Task<ModelBet?> FindById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ModelBet modelBet)
    {
        var entityBet = (EntityBet)modelBet;

        _context.Bets.Update(entityBet);

        return Task.CompletedTask;
    }
}
