using Microsoft.EntityFrameworkCore;
using CurrencyTrackerAPI.Models;

namespace CurrencyTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CurrencyLog> CurrencyLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyLog>()
                .Property(c => c.ExchangeRate)
                .HasPrecision(18, 6);
        }
    }
}