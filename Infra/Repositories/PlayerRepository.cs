using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Context;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly BetContext _context;

    public PlayerRepository(BetContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ModelPlayer modelPlayer)
    {
        var player = (EntityPlayer)modelPlayer;

        await _context.Players.AddAsync(player);
    }

    public Task Delete(ModelPlayer modelPlayer)
    {
        var player = (EntityPlayer)modelPlayer;

        _context.Players.Remove(player);

        return Task.CompletedTask;
    }

    public async Task<ICollection<ModelPlayer>> FindAll()
    {
        var players = await _context
            .Players
            .Include(player => player.Squad)
            .ThenInclude(squad => squad.Game)
            .AsNoTracking()
            .ToArrayAsync();

        var modelPlayers = new List<ModelPlayer>();

        foreach (var player in players)
        {
            modelPlayers.Add((ModelPlayer)player);
        }

        return modelPlayers;
    }

    public async Task<ModelPlayer?> FindById(Guid id)
    {
        var player = await
            _context
            .Players
            .Include(player => player.Squad)
            .AsNoTracking()
            .SingleOrDefaultAsync(player => player.Id == id);

        return (ModelPlayer)player;
    }

    public async Task<ModelPlayer> UpdateAsync(ModelPlayer modelPlayer)
    {
        var playerEntity = new EntityPlayer
        {
            Id = modelPlayer.Id,
            Name = modelPlayer.Name,
            SquadId = modelPlayer.SquadId
        };

        _context.Players.Update(playerEntity);

        return (ModelPlayer)playerEntity;
    }
}
