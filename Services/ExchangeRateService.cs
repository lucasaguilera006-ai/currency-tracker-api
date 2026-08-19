using System.Text.Json;
using CurrencyTrackerAPI.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CurrencyTrackerAPI.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly string _apiKey;

        public ExchangeRateService(HttpClient httpClient, IMemoryCache cache, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _cache = cache;
            _apiKey = configuration["ExchangeRateApiKey"]!;
        }
        public async Task<decimal> GetExchangeRateAsync(string baseCurrency, string targetCurrency)
        {
            string cacheKey = $"{baseCurrency}_{targetCurrency}";
            if (_cache.TryGetValue(cacheKey, out decimal cachedRate))
            return cachedRate;
            
            string url = $"https://v6.exchangerate-api.com/v6/{_apiKey}/pair/{baseCurrency}/{targetCurrency}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            decimal rate = doc.RootElement.GetProperty("conversion_rate").GetDecimal();

            _cache.Set(cacheKey, rate, TimeSpan.FromMinutes(10));
            return rate;
        }
    }
}