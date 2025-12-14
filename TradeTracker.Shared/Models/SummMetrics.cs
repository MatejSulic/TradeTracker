using TradeTracker.Shared.Enums;

namespace TradeTracker.Shared.Models;



public class MetricsRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public TradeSymbol? Symbol { get; set; }
    public TradeType? Type { get; set; }
    public TradeResult? Result { get; set; }

}

public class MetricsResponse
{
    public int TotalTrades { get; set; }
    public double WinRate { get; set; }
    public double AverageRRR { get; set; }
    public double AveragePnL { get; set; }
    public double TotalPnL { get; set; }

    public int MaxWinStreak { get; set; }
    public int MaxLossStreak { get; set; }
}