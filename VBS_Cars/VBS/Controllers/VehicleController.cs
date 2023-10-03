using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VBS.Models;

namespace VBS.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public VehicleController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult AddVehicle(Int16 VehicleId)
        {
            ViewBag.VehicleId = VehicleId;
            return View();
        }

        public IActionResult GridVehicle()
        {
            return View();
        }

        public IActionResult ViewVehicle()
        {
            return View();
        }
    }
}


            // POST: Handle form submission
        //    [HttpPost]
        //public  Task<IActionResult> Image(VehicleModel model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // Handle image upload and saving
        //            if (model.ImageURLs != null)
        //            {
        //                // Save the image to a directory
        //                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
        //                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageURLs;
        //                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                / model.ImageURLs.CopyToAsync(stream);
        //            }

                       
        //                model.ImageURLs = uniqueFileName;
        //            }

            

        //            return Task.FromResult<IActionResult>(RedirectToAction("Index")); // Redirect to the vehicle listing page
        //        }

        //        return Task.FromResult<IActionResult>(View(model));
        //    }
        //}



    

