using CurrencyTrackerAPI.Services;
using CurrencyTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;
        private readonly CurrencyLogService _currencyLogService;

        public CurrencyController(IExchangeRateService exchangeRateService, CurrencyLogService currencyLogService)
        {
            _exchangeRateService = exchangeRateService;
            _currencyLogService = currencyLogService;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest([FromQuery] string base_Currency, [FromQuery] string target)
        {
            var rate = await _exchangeRateService.GetExchangeRateAsync(base_Currency, target);
            await _currencyLogService.SaveLogAsync(base_Currency, target, rate);
            return Ok(new { BaseCurrency = base_Currency, TargetCurrency = target, ExchangeRate = rate });
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory([FromQuery] string base_Currency, [FromQuery] string target)
        {
            var history = await _currencyLogService.GetHistoryAsync(base_Currency, target);
            return Ok(history);
        }
    }
}