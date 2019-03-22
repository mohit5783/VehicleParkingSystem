using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleParkingSystem.Models;

namespace VehicleParkingSystem.Controllers
{
    public class AnalyticsController : Controller
    {
        Analytics analytics = new Analytics();
        List<Vehicle> allVehicles = new List<Vehicle>();
        public IActionResult Index()
        {
            if (System.IO.File.Exists("AllVehicles.json"))
            {
                allVehicles = JsonConvert.DeserializeObject<List<Vehicle>>(System.IO.File.ReadAllText("AllVehicles.json"));
            }
         
            long OneDayBefore =  (long)(DateTime.UtcNow.Subtract(DateTime.Now.AddDays(-1)).TotalSeconds);
            allVehicles = allVehicles.Where(x => x.InTime > OneDayBefore).ToList();

            analytics.Date = DateTime.Now.ToString("ddMMyyy");
            analytics.TotalSessions = allVehicles.Count();
            analytics.OngoingSessions = allVehicles.Where(x => x.IsIn == SessionStatus.OnGoing).Count();
            analytics.FinishedSessions = allVehicles.Where(x => x.IsIn == SessionStatus.Ended).Count();
            return View(analytics);
        }
    }
}