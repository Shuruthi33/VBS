using Microsoft.AspNetCore.Mvc;

namespace VBS.Controllers
{
    public class VehicleController : Controller
    {
       // [Route("~/viewVehicle")]
        public IActionResult Vehicle()
        {
            return View();
        }

        public IActionResult AddVehicle()
        {
            return View();
        }

        public IActionResult GridVehicle()
        {
            return View();
        }


    }
}
