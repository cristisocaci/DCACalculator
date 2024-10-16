namespace DCACalculator.Entities;

public partial class HistoricalData
{
    public DateOnly Date { get; set; }

    public string Symbol { get; set; } = null!;

    public float Open { get; set; }

    public float High { get; set; }

    public float Low { get; set; }

    public float Close { get; set; }
}
