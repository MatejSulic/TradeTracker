using System.ComponentModel.DataAnnotations;

namespace TradeTracker.Shared.Enums;

public enum TradeType
{
    [Display(Name = "LONG")] // Dlouhá pozice
    Long = 1,
    [Display(Name = "SHORT")] // Krátká pozice
    Short = 2
}

public enum TradeResult
{
    [Display(Name = "WIN")] // Vítězství
    Win = 1,
    [Display(Name = "LOSS")] // Prohra
    Loss = 2,
    [Display(Name = "BREAKEVEN")] // Bez Změny
    Breakeven = 3
}

public enum TradeSymbol
{


    [Display(Name = "ES")]
    ES = 1,
    [Display(Name = "NQ")]  // Nasdaq
    NQ = 2,
    [Display(Name = "MNQ")] // Mini Nasdaq
    MNQ = 3,
    [Display(Name = "MES")] // Mini S&P
    MES = 4
}