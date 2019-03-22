using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleParkingSystem.Models;

namespace VehicleParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        public List<Vehicle> AllVehicles { get; set; } = new List<Vehicle>();
        public VehicleList ObjVehicleList { get; set; } = new VehicleList();

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Vehicle vch)
        {
            AllVehicles = ObjVehicleList.LoadAllVehicles();
            vch.SessionID = 1;
            if (AllVehicles.Count >= 1)
            {
                vch.SessionID = (AllVehicles.Any() ? AllVehicles.Select(x => x.SessionID).Max() : 1) + 1;
                var isVehicleAlreadyIn = AllVehicles.Where(x => x.PlateNumber == vch.PlateNumber).Count();
                if (isVehicleAlreadyIn >= 1)//Yes this vehicle is already in and session is onGoing
                    ModelState.AddModelError(String.Empty, "This vehicle is already in the parking.");
            }
            if (ModelState.IsValid)
            {
                vch.OutMACIP = "";
                vch.InTime = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                vch.IsIn = SessionStatus.OnGoing;
                AllVehicles.Add(vch);
                ObjVehicleList.Vehicles = AllVehicles;
                ObjVehicleList.SaveVehicles(vch);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ParkOut()
        {
            return View(new VehicleList());
        }
        public IActionResult UnParkVehicle(string id)
        {
            Vehicle UnParkingVehicle = ObjVehicleList.Vehicles.Where(x => x.SessionID == Convert.ToInt16(id)).FirstOrDefault();
            return View(UnParkingVehicle);
        }
        [HttpPost]
        public IActionResult UnParkVehicle(Vehicle vcl)
        {
            if (vcl.OutMACIP != null)
            {
                ObjVehicleList.Vehicles.Where(x => x.SessionID == vcl.SessionID)
                    .Select(S =>
                    {
                        S.OutMACIP = vcl.OutMACIP;
                        S.OutTime = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        S.IsIn = SessionStatus.Ended;
                        return S;
                    }).ToList();

                ObjVehicleList.SaveVehicles(ObjVehicleList.Vehicles.Where(x => x.SessionID == vcl.SessionID).FirstOrDefault());
                return RedirectToAction("ParkOut");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please provide the IP of the Gate Barrier.");
            }
            return View(vcl);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
