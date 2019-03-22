using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace VehicleParkingSystem.Models
{
    public class SessionManager
    {
        public List<Session> Sessions { get; set; } = new List<Session>();
        public string CurrentSessionFileName { get; set; } = String.Empty;

        public SessionManager()
        {
            CurrentSessionFileName = "Sessions" + DateTime.Now.ToString("dMyy") + ".json";
        }
        public void CreateSessionfromVehcile(Vehicle vehicle)
        {
            LoadAllSessions();
            Session session = new Session()
            {
                SessionID = vehicle.SessionID,
                Platenumber = vehicle.PlateNumber,
                Status = vehicle.IsIn.ToString(),
                Intime = vehicle.InTime,
                Outtime = vehicle.OutTime,
                INAgentMACID = vehicle.InMACIP,
                OUTAgentMACID = vehicle.OutMACIP
            };
            Sessions.Add(session);
            SaveAllSessions();
        }

        public void SaveAllSessions()
        {
            File.WriteAllText(CurrentSessionFileName, JsonConvert.SerializeObject(Sessions, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        public void LoadAllSessions()
        {
            if (File.Exists(CurrentSessionFileName))
                Sessions = JsonConvert.DeserializeObject<List<Session>>(File.ReadAllText(CurrentSessionFileName));
        }
    }

}
