using Domain.Interfaces.Repositories;
using Infra.Context;

namespace Infra.Repositories;

public class UnitOfwork : IUnitOfWork
{
    private readonly BetContext _context;

    public UnitOfwork(BetContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
