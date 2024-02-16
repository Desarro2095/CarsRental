using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.SP.Messages
{
    public static class Messages
    {
        public static string GetQuerySuccessful { get; } = "Consulta satisfactoria";
        public static string GetNoQueryReturn { get; } = "La consulta no retorno datos";
        public static string GetErrorLocation { get; } = "Error, la locación de inicio no puede ser igual a la de destino";
        public static string GetLocationSuccessfull { get; } = "Alquiler del vehiculo es exitoso, buen viaje";
        public static string GetVehicleRunsOut { get; } = "Vehiculo se encuentra agotado";
        public static string GetVehicleSuccessfull { get; } = "Vehiculo seleccionado correctamente";
    }
}
