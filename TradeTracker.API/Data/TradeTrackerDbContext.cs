using Microsoft.EntityFrameworkCore;
using TradeTracker.API.Models;

namespace TradeTracker.API.Data;

public class TradeTrackerDbContext : DbContext
{
    public TradeTrackerDbContext(DbContextOptions<TradeTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Trade> Trades => Set<Trade>();
}
