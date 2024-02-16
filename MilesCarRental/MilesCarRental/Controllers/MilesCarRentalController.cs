using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MilesCarRental.BM.Location;
using MilesCarRental.BM.Vehicle;
using MilesCarRental.DT.Location;
using MilesCarRental.DT.Market;
using MilesCarRental.DT.Vehicle;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace MilesCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilesCarRentalController : Controller
    {
        private readonly IBMLocation bMLocation;
        private readonly IBMVehicle bMVehicle;

        public MilesCarRentalController(IBMLocation bMLocation, IBMVehicle bMVehicle)
        {
            this.bMLocation = bMLocation;
            this.bMVehicle = bMVehicle;
        }

        /// <summary>
        /// Consulta todos las locaciones que se tienen registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLocations")]
        public ActionResult<IEnumerable<LocationDTO>> GetAllLocations()
        {
            try
            {
                IEnumerable<LocationDTO> result = this.bMLocation.GetAllLocations();
                return StatusCode(((int)HttpStatusCode.OK), result);
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Consulta todos los vehiculos, segun la locación
        /// </summary>
        /// <param name="locationDTO"></param>
        /// <returns></returns>
        [HttpPost("GetAllVehicles")]
        public ActionResult<IEnumerable<VehicleDTO>> GetAllVehicles([FromBody] LocationDTO locationDTO)
        {
            try
            {
                IEnumerable<VehicleDTO> result = this.bMVehicle.GetAllVehicles(locationDTO.LocationName);
                return StatusCode(((int)HttpStatusCode.OK), result);
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Consulta si el vehiculo seleccionado tiene existencia segun la locacion
        /// </summary>
        /// <param name="marketDTO"></param>
        /// <returns></returns>
        [HttpPost("GetVehicle")]
        public ActionResult<MarketResultDTO<VehicleDTO>> GetVehicle([FromBody] MarketDTO marketDTO)
        {
            try
            {
                MarketResultDTO<VehicleDTO> result = this.bMVehicle.GetVehicle(marketDTO.LocationBegin.LocationName, marketDTO.Vehicle.Brand);
                return StatusCode(((int)HttpStatusCode.OK), result);
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }


        /// <summary>
        /// Consulta las localizaciones para validar que la asignación es correcta
        /// </summary>
        /// <param name="marketDTO"></param>
        /// <returns></returns>
        [HttpPost("SetLocation")]
        public ActionResult<MarketResultDTO<MarketDTO>> SetLocation([FromBody] MarketDTO marketDTO)
        {
            try
            {
                MarketResultDTO<MarketDTO> result = this.bMLocation.SetLocation(marketDTO);
                return StatusCode(((int)HttpStatusCode.OK), result);
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }
    }
}
