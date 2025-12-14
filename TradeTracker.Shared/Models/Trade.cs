using TradeTracker.Shared.Enums;

namespace TradeTracker.Shared.Models;

public class Trade
{
    public int Id { get; set; }


    public DateTime TradeDate { get; set; }

    //<summary>
    /// The symbol for the trade (e.g., ES, NQ)
    ///</summary>
    public TradeSymbol Symbol { get; set; }

    ///<summary>
    /// The type of trade (Long or Short)
    ///</summary>
    public TradeType Type { get; set; }

    ///<summary>
    /// The result of the trade (Win, Loss, Breakeven)
    ///</summary>
    public TradeResult Result { get; set; }


    //<summary>
    /// Prices associated with the trade
    ///</summary>
    public decimal EntryPrice { get; set; }
    public decimal TakeProfitPrice { get; set; }
    public decimal StopLossPrice { get; set; }

    public decimal PnL { get; set; }

    public string? Notes { get; set; }

    public string? ScreenshotPath { get; set; }

}
