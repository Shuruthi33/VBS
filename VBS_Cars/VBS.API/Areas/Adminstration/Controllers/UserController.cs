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
 * Purpose          : This controller manages user-related operations in the administration area of the API.
 *                    It handles requests to retrieve user details, retrieve details by ID, insert new user
 *                    details, and delete user records.
 ***********************************************************************************************************/


namespace VBS.API.Areas.Adminstration.Controllers
{

    [Produces(AuthAPIController.InputType.ApplicationJson)]
    [ApiController]
    [Route(AuthAPIController.Property.APIController)]
 //   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UserController : ControllerBase
    {
        public readonly IUserService _userDetailsService;

        public UserController(IUserService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }
        /// <summary>
        /// view the UserDetails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName(APIActionName.UserDetail.GetUserDetailsAsync)]
        public async Task<IActionResult> GetUserDetailsAsync()
        {
            return Ok(await _userDetailsService.GetUserDetailsAsync());
        }
        /// <summary>
        /// get the UserDetailsById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName(APIActionName.UserDetail.GetUserDetailsByIdAsync)]
        public async Task<IActionResult> GetUserDetailsByIdAsync(int id)
        {
            return Ok(await _userDetailsService.GetUserDetailsByIdAsync(id));
        }

       /// <summary>
       /// Insert the UserDetails
       /// </summary>
       /// <param name="userDetails"></param>
       /// <returns></returns>

        [HttpPost]
        [ActionName(APIActionName.UserDetail.SaveUserDetailsAsync)]
        public async Task<IActionResult> AddUserDetailsAsync([FromBody] UserDetailsDTO userDetails)
        {
            return Ok(await _userDetailsService.SaveUserDetailsAsync(userDetails));
        }

        /// <summary>
        /// Delete the User Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName(APIActionName.UserDetail.DeleteUserDetailsAsync)]
        public async Task<IActionResult> DeleteUserDetailsAsync(Int64 Id)
        {
            return Ok(await _userDetailsService.DeleteUserDetailsAsync(Id));
        }

    }
}
