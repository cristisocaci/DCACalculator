namespace DCACalculator.Models;

public class CoinMarketApiResponse
{
    public DataInfo Data { get; set; } = new();

    public class DataInfo
    {
        public Dictionary<string, CoinInfo[]> Coins { get; set; } = [];
    }

    public class CoinInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public Dictionary<string, Quote> Quote { get; set; } = [];
    }

    public class Quote
    {
        public double Price { get; set; }
    }
}
