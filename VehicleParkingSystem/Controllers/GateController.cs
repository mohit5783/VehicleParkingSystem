using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VehicleParkingSystem.Controllers
{
    public class GateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}