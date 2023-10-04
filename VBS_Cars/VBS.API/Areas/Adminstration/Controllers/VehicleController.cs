using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Service.Interface;
/***********************************************************************************************************
 * Created by       : Shuruthi
 * Created On       : 09/22/2023
 *
 * Reviewed By      :
 * Reviewed On      :
 *
 * Purpose          : This controller manages vehicle-related operations in the administration area of the API.
 *                    It handles requests to retrieve vehicle details, retrieve details by ID, insert new vehicle
 *                    details, and delete vehicle records.
 ***********************************************************************************************************/


namespace VBS.API.Areas.Adminstration.Controllers
{
    [Produces(AuthAPIController.InputType.ApplicationJson)]
    [ApiController]
    [Route(AuthAPIController.Property.APIController)]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehicleController : ControllerBase
    {
        public readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        /// <summary>
        /// View the VehicleDetails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName(APIActionName.VehicleDetails.GetVehicleDetailsAsync)]
        public async Task<IActionResult> GetVehicleDetailsAsync()
        {
            return Ok(await _vehicleService.GetVehicleDetailsAsync());
        }
        /// <summary>
        /// View the VehicleDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [ActionName(APIActionName.VehicleDetails.GetVehicleDetailsByIdAsync)]
        public async Task<IActionResult> GetVehicleDetailsByIdAsync(int id)
        {
            return Ok(await _vehicleService.GetVehicleDetailsByIdAsync(id));
        }


        /// <summary>
        /// Delete the Vehicle Details
        /// </summary>
        /// <param name="vehicleDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(APIActionName.VehicleDetails.SaveVehicleDetailsAsync)]
        public async Task<IActionResult> SaveVehicleDetailsAsync([FromBody] VehicleDetailsDTO vehicleDetails)
        {
            return Ok(await _vehicleService.SaveVehicleDetailsAsync(vehicleDetails));
        }

        /// <summary>
        /// Delete the Vehile Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName(APIActionName.VehicleDetails.DeleteVehicleDetailsAsync)]
        public async Task<IActionResult> DeleteVehicleDetailsAsync(Int64 Id)
        {
            return Ok(await _vehicleService.DeleteVehicleDetailsAsync(Id));
        }

    }
}
