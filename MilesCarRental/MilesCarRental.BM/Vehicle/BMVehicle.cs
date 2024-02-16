using MilesCarRental.DA.Vehicle;
using MilesCarRental.DT.Market;
using MilesCarRental.DT.Vehicle;
using MilesCarRental.SP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BM.Vehicle
{
    public class BMVehicle : IBMVehicle
    {
        private readonly IDAVehicle dAVehicle;

        public BMVehicle(IDAVehicle dAVehicle)
        {
            this.dAVehicle = dAVehicle;
        }

        public IEnumerable<VehicleDTO> GetAllVehicles(string location)
        {
            return this.dAVehicle.GetAllVehicles(location);
        }

        public MarketResultDTO<VehicleDTO> GetVehicle(string location, string brand)
        {
            MarketResultDTO<VehicleDTO> marketResultDTO = new MarketResultDTO<VehicleDTO>();
            VehicleDTO vehicleDTO = this.dAVehicle.GetVehicle(location, brand);
            if (string.IsNullOrEmpty(vehicleDTO.Brand))
            {
                marketResultDTO.Result = false;
                marketResultDTO.Messagge = Messages.GetVehicleRunsOut;
            }
            else
            {
                marketResultDTO.Result = true;
                marketResultDTO.Messagge = Messages.GetVehicleSuccessfull;
                marketResultDTO.Value = vehicleDTO;
            }
            return marketResultDTO;
        }
    }
}
