using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Models
{
    public class Client:Entity
    {
        public string FullName { get; set; }
        public string Comments { get; set; }
        public Order Order { get; set; }

    }
}
