using Microsoft.AspNetCore.Mvc;

namespace VBS.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult GirdFeedback()
        {
            return View();
        }
        public IActionResult AddFeedback(Int16 FeedbackId)
        {
            ViewBag.FeedbackId = FeedbackId;
            return View();
        }
    }
}
