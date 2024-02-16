using MilesCarRental.DT.Location;
using MilesCarRental.DT.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BM.Location
{
    public interface IBMLocation
    {
        LocationDTO GetLocation();

        MarketResultDTO<IEnumerable<LocationDTO>> GetAllLocations();

        MarketResultDTO<MarketDTO> SetLocation(MarketDTO marketDTO);
    }
}
