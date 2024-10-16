using DCACalculator.Models;
using DCACalculator.Utils;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace DCACalculator.Services;

public class CoinMarketCapApi
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _memoryCache;

    public CoinMarketCapApi(HttpClient httpClient, IOptions<CoinMarketCapApiOptions> options, IMemoryCache memoryCache)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(options.Value.Url);
        _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", options.Value.ApiKey);
        _memoryCache = memoryCache;
    }

    public async Task<CoinMarketApiResponse?> GetQuotes(IEnumerable<string> symbols)
    {
        var symbolsCsv = string.Join(",", symbols);
        var key = "CoinMarketCapApi-" + symbolsCsv;
        return await _memoryCache.GetOrCreateAsync(key, async cacheEntry =>
        {
            cacheEntry.SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddMinutes(5));

            var route = QueryHelpers.AddQueryString("v2/cryptocurrency/quotes/latest", "symbol", symbolsCsv);
            return await _httpClient.GetFromJsonAsync<CoinMarketApiResponse>(route);
        });
    }
}
