using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleParkingSystem.Models;

namespace VehicleParkingSystem.Controllers
{
    public class ActivityController : Controller
    {
        public ActivityManager activityManager { get; set; } = new ActivityManager();

        public IActionResult Index()
        {
            activityManager.LoadAllActivity();
            return View(activityManager.activities);
        }
    }
}