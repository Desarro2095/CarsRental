using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MilesCarRental.BM.Location;
using MilesCarRental.BM.Vehicle;
using MilesCarRental.DT.Location;
using MilesCarRental.DT.Market;
using MilesCarRental.DT.Vehicle;
using MilesCarRental.SP.Validations;
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
        public ActionResult<MarketResultDTO<IEnumerable<LocationDTO>>> GetAllLocations()
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                MarketResultDTO<IEnumerable<LocationDTO>> result = this.bMLocation.GetAllLocations();
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
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
        public ActionResult<IEnumerable<VehicleDTO>> GetAllVehicles(string location)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                MarketResultDTO<IEnumerable<VehicleDTO>> result = this.bMVehicle.GetAllVehicles(location);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
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
        public ActionResult<MarketResultDTO<VehicleDTO>> GetVehicle(string location, string brand)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                MarketResultDTO<VehicleDTO> result = this.bMVehicle.GetVehicle(location, brand);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
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
                HttpStatusCode status = HttpStatusCode.OK;
                MarketResultDTO<MarketDTO> result = this.bMLocation.SetLocation(marketDTO);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }
    }
}
