using System.Data.Entity.Spatial;

namespace POC_Map.Models
{
    public class Location
    {
        public int Id { get; set; }
        public DbGeography GeoLocation { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Address { get; set; }
    }
}