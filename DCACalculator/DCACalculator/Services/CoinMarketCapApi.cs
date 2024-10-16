namespace DCACalculator.Services
{
    public class CoinMarketCapApi
    {
        private readonly HttpClient _httpClient;

        public CoinMarketCapApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
