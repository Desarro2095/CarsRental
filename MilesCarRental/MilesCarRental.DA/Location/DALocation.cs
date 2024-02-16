using MilesCarRental.DA.Vehicle;
using MilesCarRental.DT.Location;
using MilesCarRental.DT.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DA.Location
{
    public class DALocation : IDALocation
    {
        public IEnumerable<LocationDTO> GetAllLocations()
        {
            return GetData();
        }

        public LocationDTO GetLocation(string location)
        {
            var result = GetData().Where(x=> x.LocationName == location).FirstOrDefault();
            return result == null ? new LocationDTO() : result;
        }

        private IEnumerable<LocationDTO> GetData()
        {
            List<LocationDTO> locationDTOs = new List<LocationDTO>();
            locationDTOs.Add(new LocationDTO
            {
                LocationName = "Bogota",
                Description = "Capital City"
            });
            locationDTOs.Add(new LocationDTO
            {
                LocationName = "Medellin",
                Description = " City"
            });
            locationDTOs.Add(new LocationDTO
            {
                LocationName = "Cartagena",
                Description = "City"
            });

            return locationDTOs;
        }
    }
}
