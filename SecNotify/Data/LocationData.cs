using SecNotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecNotify.Data
{
    class LocationData
    {
        /**
         * A data store for Location objects
         */

        public List<Location> Locations { get; set; } = new List<Location>();

        public LocationData()
        {
            LocationDataImporter.LoadData(this);
        }

        private static LocationData instance;
        public static LocationData GetInstance()
        {
            if (instance == null)
            {
                instance = new LocationData();
            }

            return instance;
        }


        /**
         * Returns the Location with the given ID,
         * if it exists in the store
         */
        public Location Find(int id)
        {
            var results = from loc in Locations
                          where loc.ID == id
                          select loc;

            return results.Single();
        }
    }
}
