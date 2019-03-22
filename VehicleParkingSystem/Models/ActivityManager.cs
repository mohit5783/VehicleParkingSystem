using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class ActivityManager
    {
        public List<Dictionary<int, Activity>> activities { get; set; } = new List<Dictionary<int, Activity>>();
        public string CurrentSessionFileName { get; set; } = String.Empty;

        public ActivityManager()
        {
            CurrentSessionFileName = "Activity" + DateTime.Now.ToString("dMyy") + ".json";
        }
        public void CreateActivityfromVehcile(Vehicle vehicle)
        {
            LoadAllActivity();

            Activity activity = new Activity();

            PlateNumber pn = new PlateNumber();
            pn.Image = "Some random Path";
            pn.Number = vehicle.PlateNumber;
            pn.TimeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            activity.PlateNumber = pn;
            if (vehicle.IsIn == SessionStatus.OnGoing)
            {
                activity.Type = "IN";
                activity.INAgentMACID = vehicle.InMACIP;
            }
            else
            {
                activity.Type = "OUT";
                activity.OUTAgentMACID = vehicle.OutMACIP;
            }

            Dictionary<int, Activity> myActivity = new Dictionary<int, Activity>();
            myActivity.Add((int)(vehicle.SessionID), activity);
            activities.Add(myActivity);
            SaveAllActivities();
        }

        public void SaveAllActivities()
        {
            File.WriteAllText(CurrentSessionFileName, JsonConvert.SerializeObject(activities, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        public void LoadAllActivity()
        {
            if (File.Exists(CurrentSessionFileName))
                activities = JsonConvert.DeserializeObject<List<Dictionary<int, Activity>>>(File.ReadAllText(CurrentSessionFileName));
        }
    }
}

