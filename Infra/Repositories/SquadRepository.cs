using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Context;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class SquadRepository : ISquadRepository
{
    private readonly BetContext _context;

    public SquadRepository(BetContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ModelSquad modelSquad)
    {
        var squad = (EntitySquad)modelSquad;

        await _context.Squads.AddAsync(squad);
    }

    public Task Delete(ModelSquad modelSquad)
    {
        var squad = (EntitySquad)modelSquad;

        _context.Squads.Remove(squad);

        return Task.CompletedTask;
    }

    public async Task<ICollection<ModelSquad>> FindAll()
    {
        var squads = await _context
            .Squads
            .Include(squad => squad.Game)
            .AsNoTracking()
            .ToArrayAsync();

        var modelSquads = new List<ModelSquad>();

        foreach (var squad in squads)
        {
            modelSquads.Add((ModelSquad)squad);
        }

        return modelSquads;
    }

    public async Task<ModelSquad?> FindById(Guid id)
    {
        var squad = await 
            _context
            .Squads
            .Include (squad => squad.Players)
            .Include (squad => squad.Game)
            .AsNoTracking()
            .SingleOrDefaultAsync(squad => squad.Id == id);

        return (ModelSquad)squad;
    }

    public async Task<ModelSquad> UpdateAsync(ModelSquad modelSquad)
    {
        var squadEntity = new EntitySquad
        {
            Id = modelSquad.Id,
            SquadName = modelSquad.SquadName,
            GameId = modelSquad.GameId
        };

        _context.Squads.Update(squadEntity);

        return (ModelSquad)squadEntity;
    }
}
