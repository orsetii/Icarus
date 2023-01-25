using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyApis;
using Veil.Data.Geolocation;
using Veil.Data.Stock;
using Veil.Data.Weather;

namespace Veil.Services.Database
{
    public class VeilContext : DbContext
    {
        public VeilContext(DbContextOptions options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        }
        public VeilContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("host=localhost;port=5432;database=veil;user id=postgres;password=postgres");

        public DbSet<GeolocationPosition> GeolocationPositions { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockLocation> StockLocations { get; set; }

        public DbSet<ForecastResult> WeatherForecasts { get; set; }
    }
}
