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
        VehicleDTO GetVehicle(string location, string brand);

        IEnumerable<VehicleDTO> GetAllVehicles(string location);
    }
}
