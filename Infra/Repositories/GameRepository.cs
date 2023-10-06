using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Context;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class GameRepository : IGameRepository
{
    private readonly BetContext _context;

    public GameRepository(BetContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ModelGame modelGame)
    {
        var game = (EntityGame)modelGame;

        await _context.Games.AddAsync(game);
    }

    public Task Delete(ModelGame modelGame)
    {
        var game = (EntityGame)modelGame;

        _context.Games.Remove(game);

        return Task.CompletedTask;
    }

    public async Task<ICollection<ModelGame>> FindAll()
    {
        var games = await _context
            .Games
            .Include(games => games.Squads!)
            .ThenInclude(squads => squads.Players)
            .AsNoTracking()
            .ToArrayAsync();

        var modelGames = new List<ModelGame>();

        foreach (var game in games)
        {
            modelGames.Add((ModelGame)game);
        }

        return modelGames;
    }

    public async Task<ModelGame?> FindById(Guid id)
    {
        var game = await 
            _context
            .Games
            .Include(game => game.Squads!)
            .ThenInclude(squad => squad.Players)
            .AsNoTracking()
            .SingleOrDefaultAsync(game => game.Id == id);

        return (ModelGame)game;
    }

    public async Task<ModelGame> UpdateAsync(ModelGame modelGame)
    {
        var gameEntity = new EntityGame
        {
            Id = modelGame.Id,
            Name = modelGame.Name,
            Release = modelGame.Release
        };

        _context.Games.Update(gameEntity);

        return (ModelGame)gameEntity;
    }
}
