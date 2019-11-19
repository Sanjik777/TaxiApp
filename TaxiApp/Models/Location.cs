using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Models
{
    public class Location:Entity
    {
        public double Longitude { get; set; }//долгота
        public double Latitude { get; set; }//широта
    }
}
