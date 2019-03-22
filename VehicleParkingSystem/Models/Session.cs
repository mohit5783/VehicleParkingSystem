using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class Session
    {
        [JsonProperty("SessionID")]
        public int? SessionID { get; set; }

        [JsonProperty("Platenumber")]
        public string Platenumber { get; set; }

        [JsonProperty("Intime")]
        public long? Intime { get; set; }

        [JsonProperty("Outtime")]
        public long? Outtime { get; set; }

        [JsonProperty("INAgentMACID")]
        public string INAgentMACID { get; set; }

        [JsonProperty("OUTAgentMACID")]
        public string OUTAgentMACID { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }
    }
}
