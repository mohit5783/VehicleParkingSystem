using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class Parking
    {
        [HiddenInput(DisplayValue = false)]
        public int? ParkingID { get; set; }
        [Display(Name = "Parking Name")]
        [Required(ErrorMessage = "Parking Name is required.")]
        public string ParkingName { get; set; }
        [Display(Name = "Total Parking Available")]
        public int? TotalNumberofParking { get; set; }
        [Display(Name = "Number of Ladies Parking Available")]
        public int? LadiesParking { get; set; }
        [Display(Name = "Number of Handicapped Parking Available")]
        public int? HandicappedParking { get; set; }
        [Display(Name = "How many floors parking is it?")]
        public int? ParkingFloors { get; set; }
        [Display(Name = "Parking Rates (Per Hour)")]
        public decimal? ParkingRates { get; set; } //Hourly Rate
    }
}
