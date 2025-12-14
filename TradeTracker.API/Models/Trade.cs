using TradeTracker.Shared.Enums;

namespace TradeTracker.API.Models;

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
    public double EntryPrice { get; set; }
    public double TakeProfitPrice { get; set; }
    public double StopLossPrice { get; set; }

    public double PnL { get; set; }

    public string? Notes { get; set; }

    public string? ScreenshotPath { get; set; }

}
