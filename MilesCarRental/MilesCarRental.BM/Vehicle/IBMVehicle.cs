using MilesCarRental.DT.Market;
using MilesCarRental.DT.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BM.Vehicle
{
    public interface IBMVehicle
    {
        MarketResultDTO<IEnumerable<VehicleDTO>> GetAllVehicles(string location);
        MarketResultDTO<VehicleDTO> GetVehicle(string location, string brand);
    }
}
