using POC_Map.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC_Map.Controllers
{
    public class MapDataController : Controller
    {
        // GET: MapData
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(float latitude, float longitude)
        {
            AddLocationsToDataBase(latitude, longitude);
            return View();
        }

        public ActionResult MapView(float latitude, float longitude)
        {
            var sourcePoint = CreatePoint(latitude, longitude);
            var context = new LocationContext();
            // find any locations within 15 kilometers ordered by distance
            var locations = context.Locations.Where(loc => loc.GeoLocation.Distance(sourcePoint) < 15000)
           .OrderBy(loc => loc.GeoLocation.Distance(sourcePoint)).ToList();
            return View(locations);
        }

        #region Helpers
        public static void AddLocationsToDataBase(float latitude, float longitude)
        {
            var context = new LocationContext();
            var location = new Location()
            {
                GeoLocation = CreatePoint(latitude, longitude),
                Latitude = latitude,
                Longitude = longitude
            };
            context.Locations.Add(location);
            context.SaveChanges();
        }
        public static DbGeography CreatePoint(double latitude, double longitude)
        {
            var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
            "POINT({0} {1})", longitude, latitude);
            // 4326 is most common coordinate system used by GPS/Maps
            return DbGeography.PointFromText(text, 4326);
        }
        #endregion
    }
}