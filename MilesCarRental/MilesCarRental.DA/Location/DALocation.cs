using Dapper;
using Microsoft.Extensions.Configuration;
using MilesCarRental.DA.Vehicle;
using MilesCarRental.DT.Location;
using MilesCarRental.DT.Vehicle;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DA.Location
{
    public class DALocation : IDALocation
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;
        public DALocation(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = GetConnectionString();
        }

        public IEnumerable<LocationDTO> GetAllLocations()
        {
            IEnumerable<LocationDTO> locations = new List<LocationDTO>();
            using (var connection = new MySqlConnection(this.connectionString))
            {
                IEnumerable<dynamic> result = connection.Query(Resources.Resource.GetAllLocations);
                if (result != null && result.Count() > 0)
                {
                    locations = result.Select(x => new LocationDTO() 
                    { 
                        LocationName = x.Location, 
                        Description = x.LocationDescription 
                    });
                }
            }
            return locations;
        }

        public LocationDTO GetLocation(string location)
        {
            LocationDTO locationDTO = new LocationDTO();
            using (var connection = new MySqlConnection(this.connectionString))
            {
                dynamic result = connection.QuerySingle(string.Format(Resources.Resource.GetLocation, location));
                if (result != null)
                {
                    locationDTO = new LocationDTO
                    {
                        LocationName = result.Location,
                        Description = result.LocationDescription
                    };
                }
            }
            return locationDTO;
        }

        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("MilesCarRental");
        }
    }
}
