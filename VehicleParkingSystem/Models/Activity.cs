using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class PlateNumber
    {
        public string Image { get; set; }
        public string Number { get; set; }
        public int TimeStamp { get; set; }
    }

    public class Activity
    {
        public string Type { get; set; }
        [JsonProperty("OUTAgentMACID")]
        public string OUTAgentMACID { get; set; }
        [JsonProperty("INAgentMACID")]
        public string INAgentMACID { get; set; }
        public PlateNumber PlateNumber { get; set; }
    }
}
