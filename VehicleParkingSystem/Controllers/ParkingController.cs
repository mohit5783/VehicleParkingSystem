using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleParkingSystem.Models;

namespace VehicleParkingSystem.Controllers
{
    public class ParkingController : Controller
    {// GET: /<controller>/
        public IActionResult Index()
        {
            Parking park = new Parking();
            if (System.IO.File.Exists("Parking.Config.json"))
                park = JsonConvert.DeserializeObject<Parking>(System.IO.File.ReadAllText("Parking.Config.json"));
            return View(park);
        }
        [HttpPost]
        public IActionResult Index(Parking parking)
        {
            if (ModelState.IsValid)
            {
                parking.ParkingID = 1;
                System.IO.File.WriteAllText("Parking.Config.json", JsonConvert.SerializeObject(parking, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}