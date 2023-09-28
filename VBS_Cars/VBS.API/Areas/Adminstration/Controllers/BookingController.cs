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
        /// <summary>
        /// Get the Booking Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName(APIActionName.BookingDetails.GetBookingDetailsAsync)]
        public async Task<IActionResult> GetBookingDetailsAsync()
        {
            return Ok(await _bookingService.GetBookingDetailsAsync());
        }
        /// <summary>
        /// Get the booking Details ById 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName(APIActionName.BookingDetails.GetBookingDetailsByIdAsync)]
        public async Task<IActionResult> GetBookingDetailsByIdAsync(int id)
        {
            return Ok(await _bookingService.GetBookingDetailsByIdAsync(id));
        }

        /// <summary>
        /// Insert the Booking Details
        /// </summary>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>

        [HttpPost]
        [ActionName(APIActionName.BookingDetails.SaveBookingDetailsAsync)]
        public async Task<IActionResult> SaveBookingDetailsAsync([FromBody] BookingDTO bookingDTO)
        {
            return Ok(await _bookingService.SaveBookingDetailsAsync(bookingDTO));
        }

        /// <summary>
        /// Delete the Booking Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName(APIActionName.BookingDetails.DeleteBookingDetailsAsync)]
        public async Task<IActionResult> DeleteBookingDetailsAsync(Int64 Id)
        {
            return Ok(await _bookingService.DeleteBookingDetailsAsync(Id));
        }

    }
}

