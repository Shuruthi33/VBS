using Microsoft.AspNetCore.Mvc;

namespace VBS.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult GridCustomer()
        {
            return View();
        }

        public IActionResult AddOrUpdateCustomer(Int16 CustomerId = 0)
        {
            ViewBag.CustomerId = CustomerId;
            return View();
        }
        //public IActionResult Edit()
        //{
        //    return View();
        //}
        public IActionResult Edit(Int16 CustomerId=0)
        {
            ViewBag.CustomerId = CustomerId;
           
            return View();  
        }
    }
}
