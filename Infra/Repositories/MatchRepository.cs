using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Context;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class MatchRepository : IMatchRepository
{
    private readonly BetContext _context;

    public MatchRepository(BetContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ModelMatch modelMatch)
    {
        var entityMatch = (EntityMatch)modelMatch;

        await _context.Matches.AddAsync(entityMatch);
    }

    public Task Delete(ModelMatch modelMatch)
    {
        var entityMatch = (EntityMatch)modelMatch;

        _context.Matches.Remove(entityMatch);

        return Task.CompletedTask;
    }

    public async Task<ICollection<ModelMatch>> FindAll()
    {
        var matches = await 
            _context
            .Matches
            .Include(matches => matches.SquadOne)
                .ThenInclude(squadOne => squadOne.Players)
            .Include(matches => matches.SquadTwo)
                .ThenInclude(squadTwo => squadTwo.Players)
            .AsNoTracking()
            .ToArrayAsync();

        var modelMatches = new List<ModelMatch>();

        foreach (var match in matches)
        {
            modelMatches.Add((ModelMatch)match);
        }

        return modelMatches;
    }

    public async Task<ModelMatch?> FindById(Guid matchId)
    {
        var match = await
            _context
            .Matches
            .Include(matches => matches.SquadOne)
                .ThenInclude(squadOne => squadOne.Players)
            .Include(matches => matches.SquadTwo)
                .ThenInclude(squadTwo => squadTwo.Players)
            .AsNoTracking()
            .SingleOrDefaultAsync(match => match.Id == matchId);

        return (ModelMatch)match;
    }

    public async Task<ModelMatch> UpdateAsync(ModelMatch modelMatch)
    {
        var entityMatch = (EntityMatch)modelMatch;

        _context.Matches.Update(entityMatch);

        return (ModelMatch)entityMatch;
    }
}
