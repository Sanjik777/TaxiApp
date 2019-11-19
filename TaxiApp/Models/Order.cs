using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Models
{
    public class Order:Entity
    {
        public string State { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
    }
}
