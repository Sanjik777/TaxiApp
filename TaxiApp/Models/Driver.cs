using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Models
{
    public class Driver : Entity
    {
        public string FullName {get;set;}
        public string Car { get; set; }
        public List<Order> Orders { get; set; }
    }
}
