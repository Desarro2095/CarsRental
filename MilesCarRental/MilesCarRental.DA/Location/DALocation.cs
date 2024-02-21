using Dapper;
using Microsoft.Extensions.Configuration;
using MilesCarRental.DA.Vehicle;
using MilesCarRental.DT.Location;
using MilesCarRental.DT.Market;
using MilesCarRental.DT.Vehicle;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

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

        /// <summary>
        /// Consulta todos las locaciones que se tienen registrados
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Consulta la localización segun el parametro enviado
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Realiza la inserción de la localizacion de inicio y fin seleccionada
        /// </summary>
        /// <param name="marketDTO"></param>
        /// <returns></returns>
        public bool SetLocation(MarketDTO marketDTO)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                int result = connection.Execute(string.Format(
                    Resources.Resource.SetLocation, 
                    marketDTO.LocationBegin.LocationName, 
                    marketDTO.LocationEnd.LocationName));
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna la cadena de conexión a base de datos
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("MilesCarRental");
        }
    }
}
