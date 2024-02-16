using MilesCarRental.DT.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DA.Vehicle
{
    public class DAVehicle : IDAVehicle
    {
        public IEnumerable<VehicleDTO> GetAllVehicles(string location)
        {
            return GetData(location);
        }

        public VehicleDTO GetVehicle(string location, string brand)
        {
            var result = GetData(location).Where(x=> x.Brand == brand && x.AmountAvaible > 0).FirstOrDefault();
            return result == null ? new VehicleDTO() : result;
        }

        private IEnumerable<VehicleDTO> GetData(string location)
        {
            List<VehicleDTO> vehicleDTOs = new List<VehicleDTO>();

            switch (location)
            {
                case "Bogota":
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "Volvo",
                        Description = "Truck",
                        AmountAvaible = 5
                    });
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "Ford",
                        Description = "Family",
                        AmountAvaible = 5
                    });
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "Hyundai",
                        Description = "Compact",
                        AmountAvaible = 5
                    });
                    break;
                case "Medellin":
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "BMW",
                        Description = "Classic",
                        AmountAvaible = 5
                    });
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "KIA",
                        Description = "Sport",
                        AmountAvaible = 5
                    });
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "Nissan",
                        Description = "Future",
                        AmountAvaible = 5
                    });
                    break;
                case "Cartagena":
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "Renault",
                        Description = "Hybrid",
                        AmountAvaible = 5
                    });
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "Mazda",
                        Description = "Large",
                        AmountAvaible = 5
                    });
                    vehicleDTOs.Add(new VehicleDTO
                    {
                        Brand = "Suzuki",
                        Description = "Small",
                        AmountAvaible = 5
                    });
                    break;
            }
            return vehicleDTOs;
        }
    }
}
