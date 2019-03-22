using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class VehicleList
    { 
        public SessionManager sessionManager { get; set; } = new SessionManager();
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ActivityManager activityManger { get; set; } = new ActivityManager();
        public VehicleList()
        {
            Vehicles = LoadAllVehicles();
        }

        public List<Vehicle> LoadAllVehicles()
        {
            if (File.Exists("AllVehicles.json"))
                return JsonConvert.DeserializeObject<List<Vehicle>>(File.ReadAllText("AllVehicles.json")).Where(x => x.IsIn == SessionStatus.OnGoing).ToList();

            return new List<Vehicle>();
        }
        public void SaveVehicles(Vehicle vcl)
        {
            File.WriteAllText("AllVehicles.json", JsonConvert.SerializeObject(Vehicles, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));

            sessionManager.CreateSessionfromVehcile(vcl);
            activityManger.CreateActivityfromVehcile(vcl);

        }

    }
}
