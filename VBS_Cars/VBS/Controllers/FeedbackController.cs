using Microsoft.AspNetCore.Mvc;

namespace VBS.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult GirdFeedback()
        {
            return View();
        }
        public IActionResult AddFeedback()
        {
            return View();
        }
    }
}
