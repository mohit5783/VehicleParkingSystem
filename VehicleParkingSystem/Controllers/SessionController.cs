using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleParkingSystem.Models;

namespace VehicleParkingSystem.Controllers
{
    public class SessionController : Controller
    {
        public SessionManager sessionManager { get; set; } = new SessionManager();
        public IActionResult Index()
        {
            sessionManager.LoadAllSessions();
            return View(sessionManager.Sessions);
        }
    }
}