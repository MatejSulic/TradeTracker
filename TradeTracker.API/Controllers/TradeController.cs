using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeTracker.API.Data;
using TradeTracker.API.Models;

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
    public async Task<ActionResult<IEnumerable<Trade>>> GetTrades()
    {
        return await _context.Trades.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Trade>> GetTrade(int id){
        var trade = await _context.Trades.FindAsync(id);
        if (trade == null)
        {
            return NotFound();
        }
        return trade;
    }

    [HttpPost]
    public async Task<ActionResult<Trade>> CreateTrade(Trade trade)
    {
        _context.Trades.Add(trade);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTrade), new { id = trade.Id }, trade);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrade(int id, Trade trade)
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


        
}