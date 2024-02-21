using MilesCarRental.DT.Location;
using MilesCarRental.DT.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DA.Location
{
    public interface IDALocation
    {
        /// <summary>
        /// Consulta la localización segun el parametro enviado
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        LocationDTO GetLocation(string location);

        /// <summary>
        /// Consulta todos las locaciones que se tienen registrados
        /// </summary>
        /// <returns></returns>
        IEnumerable<LocationDTO> GetAllLocations();

        /// <summary>
        /// Realiza la inserción de la localizacion de inicio y fin seleccionada
        /// </summary>
        /// <param name="marketDTO"></param>
        /// <returns></returns>
        bool SetLocation(MarketDTO marketDTO);
    }
}
