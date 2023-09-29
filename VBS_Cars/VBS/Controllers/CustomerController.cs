using Microsoft.AspNetCore.Mvc;

namespace VBS.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult AddOrUpdateCustomer()
        {
            return View();
        }
    }
}
