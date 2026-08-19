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
    }
}