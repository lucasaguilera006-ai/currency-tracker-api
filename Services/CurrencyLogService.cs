using CurrencyTrackerAPI.Data;
using CurrencyTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyTrackerAPI.Services
{
    public class CurrencyLogService
    {
        private readonly AppDbContext _context;

        public CurrencyLogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveLogAsync(string baseCurrency, string targetCurrency, decimal rate)
        {
            var log = new CurrencyLog
            {
                BaseCurrency = baseCurrency,
                TargetCurrency = targetCurrency,
                ExchangeRate = rate
            };

            _context.CurrencyLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CurrencyLog>> GetHistoryAsync(string baseCurrency, string targetCurrency)
        {
            return await _context.CurrencyLogs
                .Where(l => l.BaseCurrency == baseCurrency && l.TargetCurrency == targetCurrency)
                .OrderByDescending(l => l.ConsultedAt)
                .ToListAsync();
        }
    }
}