using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.DT.Market
{
    public class MarketResultDTO<T> 
    {
        public bool Result { get; set; }
        public string Messagge { get; set; }
        public T Value { get; set; }
    }
}
