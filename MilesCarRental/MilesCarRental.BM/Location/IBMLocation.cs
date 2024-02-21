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
        /// <summary>
        /// Consulta todos las locaciones que se tienen registrados
        /// </summary>
        /// <returns></returns>
        MarketResultDTO<IEnumerable<LocationDTO>> GetAllLocations();


        /// <summary>
        /// Realiza la validaciones de las localizaciones seleccionadas
        /// </summary>
        /// <param name="marketDTO"></param>
        /// <returns></returns>
        MarketResultDTO<MarketDTO> SetLocation(MarketDTO marketDTO);
    }
}
