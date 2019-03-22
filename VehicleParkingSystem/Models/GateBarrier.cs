using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class GateBarrier
    {
        public int? GateID { get; set; }
        public string GateName { get; set; }
        public string GateIP { get; set; }
        public int? PortNumber { get; set; }
        public string URL { get; set; }
    }
}
