namespace CurrencyTrackerAPI.Services.Interfaces
{
    public interface IExchangeRateService
    {
        Task<decimal> GetExchangeRateAsync(string baseCurrency, string targetCurrency);
    }
}
