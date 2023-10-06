using Infra.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class BetContext : IdentityDbContext<EntityUser>
{
    public DbSet<EntityGame> Games { get; set; }

    public DbSet<EntitySquad> Squads { get; set; }

    public DbSet<EntityPlayer> Players { get; set; }

    public DbSet<EntityMatch> Matches { get; set; }

    public DbSet<EntityBet> Bets { get; set; }

    public DbSet<EntityAdministrativeAccessRequest> AccessRequests { get; set; }

    public BetContext(DbContextOptions<BetContext> opts) : base(opts)
    {
        
    }
}