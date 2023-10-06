using Domain.Models;
using Infra.Context;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class AccessRequestRepository
{
    private readonly BetContext _context;

    public AccessRequestRepository(BetContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ModelAskForAdminAccess accessRequest)
    {
        var adminRequest = (EntityAdministrativeAccessRequest)accessRequest;

        await _context.AddAsync(adminRequest);
    }

    public async Task<ICollection<ModelAskForAdminAccess>> GetAllAccessRequestsAsync()
    {
         var requests = await _context
            .AccessRequests
            .AsNoTracking()
            .Include(accessRequest =>  accessRequest.User)
            .ToArrayAsync();

        var adminRequests = new List<ModelAskForAdminAccess>();

        foreach (var request in requests)
        {
            adminRequests.Add((ModelAskForAdminAccess)request);
        }

        return adminRequests;
    }

    public async Task<ModelAskForAdminAccess> FindAccessRequestByIdAsync(EntityAdministrativeAccessRequest accessRequest)
    {
        var request = await _context.AccessRequests
            .AsNoTracking()
            .Include(accessRequest => accessRequest.User)
            .SingleOrDefaultAsync(request => request.Id == accessRequest.Id);
        
        return (ModelAskForAdminAccess)request;
    }

    public Task Delete(EntityAdministrativeAccessRequest accessRequest)
    {
        _context.AccessRequests.Remove(accessRequest);

        return Task.CompletedTask;
    }
}
