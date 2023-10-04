using Microsoft.AspNetCore.Mvc;

namespace VBS.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult GridBooking()
        {
            return View();
        }
        public IActionResult AddBooking(Int16 BookingId)
        {
            ViewBag.BookingId = BookingId;
            return View();
        }
        
             public IActionResult AddBookingNew(Int16 BookingId)
        {
            ViewBag.BookingId = BookingId;
            return View();
        }
    }
}
