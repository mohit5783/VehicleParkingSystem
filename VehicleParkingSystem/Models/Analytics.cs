using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class Analytics
    {
        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("TotalSessions")]
        public int TotalSessions { get; set; }

        [JsonProperty("OngoingSessions")]
        public int OngoingSessions { get; set; }

        [JsonProperty("FinishedSessions")]
        public int FinishedSessions { get; set; }
    }
}
