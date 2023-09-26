using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Service.Interface;

namespace VBS.API.Areas.Adminstration.Controllers
{
  
 

   [Produces(AuthAPIController.InputType.ApplicationJson)]
   [ApiController]
   [Route(AuthAPIController.Property.APIController)]
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookingController : ControllerBase
    {
        public readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [ActionName(APIActionName.BookingDetails.GetBookingDetailsAsync)]
        public async Task<IActionResult> GetBookingDetailsAsync()
        {
            return Ok(await _bookingService.GetBookingDetailsAsync());
        }

        [HttpGet]
        [ActionName(APIActionName.BookingDetails.GetBookingDetailsByIdAsync)]
        public async Task<IActionResult> GetBookingDetailsByIdAsync(int id)
        {
            return Ok(await _bookingService.GetBookingDetailsByIdAsync(id));
        }



        [HttpPost]
        [ActionName(APIActionName.BookingDetails.SaveBookingDetailsAsync)]
        public async Task<IActionResult> SaveBookingDetailsAsync([FromBody] BookingDTO bookingDTO)
        {
            return Ok(await _bookingService.SaveBookingDetailsAsync(bookingDTO));
        }


        [HttpDelete]
        [ActionName(APIActionName.BookingDetails.DeleteBookingDetailsAsync)]
        public async Task<IActionResult> DeleteBookingDetailsAsync(Int64 Id)
        {
            return Ok(await _bookingService.DeleteBookingDetailsAsync(Id));
        }

    }
}

