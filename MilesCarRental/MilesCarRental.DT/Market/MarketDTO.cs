using MilesCarRental.DT.Location;
using MilesCarRental.DT.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DT.Market
{
    public class MarketDTO
    {
        public LocationDTO LocationBegin { get; set; }
        public LocationDTO LocationEnd { get; set; }
        public VehicleDTO Vehicle { get; set; }
    }
}
