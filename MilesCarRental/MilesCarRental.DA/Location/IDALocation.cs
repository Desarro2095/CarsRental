using MilesCarRental.DT.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DA.Location
{
    public interface IDALocation
    {
        LocationDTO GetLocation(string location);

        IEnumerable<LocationDTO> GetAllLocations();
    }
}
