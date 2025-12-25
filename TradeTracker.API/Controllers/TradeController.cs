using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeTracker.API.Data;
using TradeTracker.API.Models;
using TradeTracker.Shared.Models;

namespace TradeTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradeController : ControllerBase
{
    private readonly TradeTrackerDbContext _context;
    public TradeController(TradeTrackerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Trade>>> GetTrades()
    {
        return await _context.Trades.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Trade>> GetTrade(int id){
        var trade = await _context.Trades.FindAsync(id);
        if (trade == null)
        {
            return NotFound();
        }
        return trade;
    }

    [HttpPost]
    public async Task<ActionResult<Models.Trade>> CreateTrade(TradeToShare trade)
    {
        Trade trade1 = new Trade
        {
            TradeDate = trade.TradeDate,
            Symbol = trade.Symbol,
            Type = trade.Type,
            Result = trade.Result,
            EntryPrice = trade.EntryPrice,
            TakeProfitPrice = trade.TakeProfitPrice,
            StopLossPrice = trade.StopLossPrice,
            PnL = trade.PnL,
            Notes = trade.Notes,
            ScreenshotPath = trade.ScreenshotPath
        };
        _context.Trades.Add(trade1);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTrade), new { id = trade1.Id }, trade1);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrade(int id, TradeToShare trade)
    {
        if (id != trade.Id)
        {
            return BadRequest();
        }

        _context.Entry(trade).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrade(int id){
        var trade = await _context.Trades.FindAsync(id);
        if (trade == null)
        {
            return NotFound();
        }

        _context.Trades.Remove(trade);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("metrics")]
    public async Task<ActionResult<MetricsResponse>> GetMetrics(MetricsRequest request)
    {

        
        List<Models.Trade> trades = _context.GetFilteredTrades(request);
        CountingFunctions counter = new CountingFunctions();
        var response = new MetricsResponse
        {
            TotalTrades = counter.GetTotalTrades(trades),
            WinRate = counter.CalculateWinRate(trades),
            AverageRRR = counter.CalculateAverageRRR(trades),
            AveragePnL = counter.CalculateAveragePnL(trades),
            TotalPnL = counter.CalculateTotalPnL(trades),
            MaxWinStreak = counter.CalculateMaxWinStreak(trades),
            MaxLossStreak = counter.CalculateMaxLossStreak(trades)
        };

        return Ok(response);
    }

    [HttpPost("filter")]
    public async Task<ActionResult<IEnumerable<Models.Trade>>> GetFilteredTrades( MetricsRequest request)
    {
        var trades = _context.GetFilteredTrades(request);
        return Ok(trades);
    }
    
}