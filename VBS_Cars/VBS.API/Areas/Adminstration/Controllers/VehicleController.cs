using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Service.Interface;

namespace VBS.API.Areas.Adminstration.Controllers
{
    //    [Route("api/[controller]/[action]")]
    //    [ApiController]

    [Produces(AuthAPIController.InputType.ApplicationJson)]
    [ApiController]
    [Route(AuthAPIController.Property.APIController)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehicleController : ControllerBase
    {
        public readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet]
        [ActionName(APIActionName.VehicleDetails.GetVehicleDetailsAsync)]
        public async Task<IActionResult> GetVehicleDetailsAsync()
        {
            return Ok(await _vehicleService.GetVehicleDetailsAsync());
        }

        [HttpGet]
        [ActionName(APIActionName.VehicleDetails.GetVehicleDetailsByIdAsync)]
        public async Task<IActionResult> GetVehicleDetailsByIdAsync(int id)
        {
            return Ok(await _vehicleService.GetVehicleDetailsByIdAsync(id));
        }



        [HttpPost]
        [ActionName(APIActionName.VehicleDetails.SaveVehicleDetailsAsync)]
        public async Task<IActionResult> SaveVehicleDetailsAsync([FromBody] VehicleDetailsDTO vehicleDetails)
        {
            return Ok(await _vehicleService.SaveVehicleDetailsAsync(vehicleDetails));
        }


        [HttpDelete]
        [ActionName(APIActionName.VehicleDetails.DeleteVehicleDetailsAsync)]
        public async Task<IActionResult> DeleteVehicleDetailsAsync(Int64 Id)
        {
            return Ok(await _vehicleService.DeleteVehicleDetailsAsync(Id));
        }

    }
}
