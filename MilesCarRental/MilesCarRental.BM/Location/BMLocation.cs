using MilesCarRental.DA.Location;
using MilesCarRental.DT.Location;
using MilesCarRental.DT.Market;
using MilesCarRental.SP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.BM.Location
{
    public class BMLocation : IBMLocation
    {
        private readonly IDALocation dALocation; 

        public BMLocation(IDALocation dALocation)
        {
            this.dALocation = dALocation;
        }

        /// <summary>
        /// Consulta todos las locaciones que se tienen registrados
        /// </summary>
        /// <returns></returns>
        public MarketResultDTO<IEnumerable<LocationDTO>> GetAllLocations()
        {
            MarketResultDTO<IEnumerable<LocationDTO>> marketResultDTO = new MarketResultDTO<IEnumerable<LocationDTO>>();
            IEnumerable<LocationDTO> result = this.dALocation.GetAllLocations();
            if (result != null && result.Count() > 0)
            {
                marketResultDTO.Result = false;
                marketResultDTO.Messagge = Messages.GetQuerySuccessful;
                marketResultDTO.Value = result;
            }
            else
            {
                marketResultDTO.Result = false;
                marketResultDTO.Messagge = Messages.GetNoQueryReturn;
            }
            return marketResultDTO;
        }

        /// <summary>
        /// Realiza la validaciones de las localizaciones seleccionadas
        /// </summary>
        /// <param name="marketDTO"></param>
        /// <returns></returns>
        public MarketResultDTO<MarketDTO> SetLocation(MarketDTO marketDTO)
        {
            MarketResultDTO<MarketDTO> marketResultDTO = new MarketResultDTO<MarketDTO>();
            LocationDTO locationDTO = this.dALocation.GetLocation(marketDTO.LocationEnd.LocationName);
            if (locationDTO.LocationName.Equals(marketDTO.LocationBegin.LocationName))
            {
                marketResultDTO.Result = false;
                marketResultDTO.Messagge = Messages.GetErrorLocation;
            }
            else
            {
                if (this.dALocation.SetLocation(marketDTO))
                {
                    marketResultDTO.Result = true;
                    marketResultDTO.Messagge = Messages.GetLocationSuccessfull;
                    marketResultDTO.Value = marketDTO;
                }
            }
            return marketResultDTO;
        }

    }
}
