using Microsoft.EntityFrameworkCore;
using TradeTracker.API.Models;
using TradeTracker.Shared.Models;

namespace TradeTracker.API.Data;

public class TradeTrackerDbContext : DbContext
{
    public TradeTrackerDbContext(DbContextOptions<TradeTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Trade> Trades => Set<Models.Trade>();


    public List<Models.Trade> GetFilteredTrades(MetricsRequest request)
    {
        var query = Trades.AsQueryable();

        if (request.StartDate.HasValue)
        {
            query = query.Where(t => t.TradeDate >= request.StartDate.Value);
        }

        if (request.EndDate.HasValue)
        {
            query = query.Where(t => t.TradeDate <= request.EndDate.Value);
        }

        if (request.Symbol.HasValue)
        {
            query = query.Where(t => t.Symbol == request.Symbol.Value);
        }

        if (request.Type.HasValue)
        {
            query = query.Where(t => t.Type == request.Type.Value);
        }

        if (request.Result.HasValue)
        {
            query = query.Where(t => t.Result == request.Result.Value);
        }

        return query.ToList();
    }
        
}
