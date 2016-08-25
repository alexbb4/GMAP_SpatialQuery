using System.Data.Entity;

namespace POC_Map.Data
{
    public class LocationContext : DbContext
    {
        public LocationContext() : base("mapcon")
        {

        }
        public DbSet<Location> Locations { get; set; }
    }
}