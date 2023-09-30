using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VBS.Framework.Helper;
using VBS.Models;
using VBS.Models.Input;
using VBS.Models.Output;
using VBS.Service.Interface;

namespace VBS.API.Controllers
{
        [Produces(AuthAPIController.InputType.ApplicationJson)]
        [ApiController]
        [Route(AuthAPIController.Property.APIController)]
        [AllowAnonymous]
        public class UserAuthenticationController : ControllerBase
        {
            private readonly IAuthenticateService _user;
            private readonly JWTSetting authentication;

            #region Constructor

            public UserAuthenticationController(IAuthenticateService user, IOptions<JWTSetting> options)
            {
                _user = user;
                authentication = options.Value;
            }

            #endregion Constructor

            #region Methods

            /// <summary>
            ///  User Authentication
            /// </summary>
            /// <returns>this will return the user data as object</returns>
            /// <remarks>
            /// Sample request:
            /// POST /Todo
            ///  {
            ///  "userName": "admin",
            ///  "password": "admin"
            /// }
            /// </remarks>
            /// <response code="200">success</response>
            /// <response code="204">User Not Found</response>
            [HttpPost]
            [ActionName(APIActionName.Login.Authenticate)]
            public async Task<IActionResult> AuthenticateAsync([FromBody] UserCredential user)
            {
                var Response = new UserDetailsResult();
           
                try
                {
                    Response = await _user.AuthenticateUserAsync(user);
                    if (Response.UserDetails == null || Response.StatusCode != 200)
                        return Unauthorized(Response);
                    var tokenhandler = new JwtSecurityTokenHandler();
                    var tokenkey = Encoding.UTF8.GetBytes("vehiclebsffffffffffffff");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                        new Claim(ClaimTypes.Name,Response.UserDetails.CustomerName),
                        new Claim(ClaimTypes.Role,Response.UserDetails.RoleId.ToString())
                            }
                        ),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                    };
                    var token = tokenhandler.CreateToken(tokenDescriptor);
                    string finaltoken = tokenhandler.WriteToken(token);
                // Response.JWTToken = finaltoken;
                Response.UserDetails.JWTToken = finaltoken;
            }
                catch (Exception ex)
                {
                    new ErrorLog().WriteLog(ex);
                    return Unauthorized();
                }
           
                return Ok(Response);
            }

            #endregion Methods
        }
    
}
