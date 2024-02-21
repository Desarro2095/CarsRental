using Dapper;
using Microsoft.Extensions.Configuration;
using MilesCarRental.DT.Location;
using MilesCarRental.DT.Vehicle;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DA.Vehicle
{
    public class DAVehicle : IDAVehicle
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;
        public DAVehicle(IConfiguration configuration) 
        {
            this.configuration = configuration;
            this.connectionString = GetConnectionString();
        }

        public IEnumerable<VehicleDTO> GetAllVehicles(string location)
        {
            IEnumerable<VehicleDTO> vehicles = new List<VehicleDTO>();
            using (var connection = new MySqlConnection(this.connectionString))
            {
                IEnumerable<dynamic> result = connection.Query(Resources.Resource.GetAllVehicles);
                if (result != null && result.Count() > 0)
                {
                    vehicles = result.Select(x => new VehicleDTO()
                    {
                        Brand = x.Vehicle,
                        Description = x.VehicleDescription,
                        AmountAvaible = x.AmountAvaible
                    });
                }
            }
            return vehicles;
        }

        public VehicleDTO GetVehicle(string location, string brand)
        {
            VehicleDTO vehicleDTO = new VehicleDTO();
            using (var connection = new MySqlConnection(this.connectionString))
            {
                dynamic result = connection.QuerySingle(string.Format(Resources.Resource.GetVehicle, brand, location));
                if (result != null)
                {
                    vehicleDTO = new VehicleDTO
                    {
                        Brand = result.Vehicle,
                        Description = result.VehicleDescription,
                        AmountAvaible = result.AmountAvaible
                    };
                }
            }
            return vehicleDTO;
        }

        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("MilesCarRental");
        }
    }
}
