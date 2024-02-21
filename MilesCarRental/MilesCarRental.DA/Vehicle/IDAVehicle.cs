using MilesCarRental.DT.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DA.Vehicle
{
    public interface IDAVehicle
    {
        /// <summary>
        /// Consulta si el vehiculo seleccionado tiene existencia segun la locacion
        /// </summary>
        /// <param name="location"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        VehicleDTO GetVehicle(string location, string brand);

        /// <summary>
        /// Consulta todos los vehiculos, segun la locación
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        IEnumerable<VehicleDTO> GetAllVehicles(string location);
    }
}
