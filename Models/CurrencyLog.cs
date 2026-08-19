namespace CurrencyTrackerAPI.Models
{
    public class CurrencyLog
    {
        public int Id { get; set; }
        public string BaseCurrency { get; set; } = string.Empty;
        public string TargetCurrency { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; }
        public DateTime ConsultedAt { get; set; } = DateTime.UtcNow;
    }
}