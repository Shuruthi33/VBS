using Microsoft.AspNetCore.Mvc;

namespace VBS.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult GridBooking()
        {
            return View();
        }
    }
}
