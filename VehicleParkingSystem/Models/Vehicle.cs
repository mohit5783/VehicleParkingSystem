using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleParkingSystem.Models
{
    public class Vehicle
    {
        public int? SessionID { get; set; }
        [Display(Name = "Vehcile Registration Number")]
        [Required(ErrorMessage = "Vehicle Registration Number (Plate Number) is required.")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$", ErrorMessage = "Plate Number must be containing the combination of Numbers and Alphabets.")]
        public string PlateNumber { get; set; }
        [Display(Name = "In Time")]
        public long? InTime { get; set; }
        [Display(Name = "Out Time")]
        public long? OutTime { get; set; }
        [Display(Name = "[IN] Gate Barrier IP")]
        [Required(ErrorMessage = "Gate Barrier's IP is required")]
        [RegularExpression("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", ErrorMessage = "Only Valid IPs can be entered.")]
        public string InMACIP { get; set; }
        [Display(Name = "[OUT] Gate Barrier IP")]
        [RegularExpression("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", ErrorMessage = "Only Valid IPs can be entered.")]
        public string OutMACIP { get; set; }
        public SessionStatus? IsIn { get; set; }

    }

}
