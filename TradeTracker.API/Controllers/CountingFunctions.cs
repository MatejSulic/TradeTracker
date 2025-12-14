using TradeTracker.API.Models;
using TradeTracker.Shared.Enums;


namespace TradeTracker.API.Controllers;

class CountingFunctions
{

    public double CalculateWinRate(IEnumerable<Trade> trades)
    {
        if (!trades.Any()) return 0.0;

        double winrate = 0.0;
        int winCount = trades.Count(t => t.Result == TradeResult.Win);
        int lossCount = trades.Count(t => t.Result == TradeResult.Loss);

        winrate = (double)winCount / (winCount + lossCount) * 100.0;
        return Math.Round(winrate, 2);
    }

    public int GetTotalTrades(IEnumerable<Trade> trades)
    {
        return trades.Count();
    }


    public double CalculateAverageRRR(IEnumerable<Trade> trades)
    {
        if (!trades.Any()) return 0.0;

        double totalRRR = 0.0;
        int count = 0;

        foreach (var trade in trades)
        {
            double risk = Math.Abs(trade.EntryPrice - trade.StopLossPrice);
            double reward = Math.Abs(trade.TakeProfitPrice - trade.EntryPrice);

            if (risk > 0)
            {
                totalRRR += reward / risk;
                count++;
            }
        }

        if (count == 0) return 0.0;

        double averageRRR = totalRRR / count;
        return Math.Round(averageRRR, 2);
    }

    public double CalculateAveragePnL(IEnumerable<Trade> trades)
    {
        if (!trades.Any()) return 0.0;

        double totalPnL = trades.Sum(t => t.PnL);
        double averagePnL = totalPnL / trades.Count();

        return Math.Round(averagePnL, 2);
    }

    public double CalculateTotalPnL(IEnumerable<Trade> trades)
    {
        if (!trades.Any()) return 0.0;

        double totalPnL = trades.Sum(t => t.PnL);
        return Math.Round(totalPnL, 2);
    }

    public int CalculateMaxWinStreak(IEnumerable<Trade> trades)
    {
        int maxWinStreak = 0;
        int currentWinStreak = 0;
        
        foreach (var trade in trades)
        {
            if (trade.Result == TradeResult.Win)
            {
                currentWinStreak++;
                if (currentWinStreak > maxWinStreak)
                {
                    maxWinStreak = currentWinStreak;
                }
            }
            else
            {
                currentWinStreak = 0;
            }
        }
        return maxWinStreak;
    }

    public int CalculateMaxLossStreak(IEnumerable<Trade> trades)
    {
        int maxLossStreak = 0;
        int currentLossStreak = 0;
        
        foreach (var trade in trades)
        {
            if (trade.Result == TradeResult.Loss)
            {
                currentLossStreak++;
                if (currentLossStreak > maxLossStreak)
                {
                    maxLossStreak = currentLossStreak;
                }
            }
            else
            {
                currentLossStreak = 0;
            }
        }
        return maxLossStreak;
    }
}
