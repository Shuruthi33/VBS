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

    public class UserController : ControllerBase
    {
        public readonly IUserService _userDetailsService;

        public UserController(IUserService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }
        [HttpGet]
        [ActionName(APIActionName.UserDetail.GetUserDetailsAsync)]
        public async Task<IActionResult> GetUserDetailsAsync()
        {
            return Ok(await _userDetailsService.GetUserDetailsAsync());
        }

        [HttpGet]
        [ActionName(APIActionName.UserDetail.GetUserDetailsByIdAsync)]
        public async Task<IActionResult> GetUserDetailsByIdAsync(int id)
        {
            return Ok(await _userDetailsService.GetUserDetailsByIdAsync(id));
        }

       

        [HttpPost]
        [ActionName(APIActionName.UserDetail.SaveUserDetailsAsync)]
        public async Task<IActionResult> AddUserDetailsAsync([FromBody] UserDetailsDTO userDetails)
        {
            return Ok(await _userDetailsService.SaveUserDetailsAsync(userDetails));
        }


        [HttpDelete]
        [ActionName(APIActionName.UserDetail.DeleteUserDetailsAsync)]
        public async Task<IActionResult> DeleteUserDetailsAsync(Int64 Id)
        {
            return Ok(await _userDetailsService.DeleteUserDetailsAsync(Id));
        }

    }
}
