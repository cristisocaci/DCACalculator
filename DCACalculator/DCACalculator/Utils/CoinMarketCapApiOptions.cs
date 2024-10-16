namespace DCACalculator.Utils;

public class CoinMarketCapApiOptions
{
    public const string CoinMarketCapApi = "CoinMarketCapApi";
    public string Url { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}
