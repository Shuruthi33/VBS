using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using VBS.Models.Input;
using AuthUserResultArgs = VBS.Models.Output.UserDetailsResult;

namespace VBS.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredential userCredential)
        {
            AuthUserResultArgs result = new AuthUserResultArgs();
            try
            {
                result = UserAuthentication(userCredential);
            }
            catch (Exception ex)
            {

            }

            return Ok(result);
        }


        private AuthUserResultArgs UserAuthentication(UserCredential userCredential)
        {
            var baseUrl = "https://localhost:7011/api/";

            AuthUserResultArgs result = new AuthUserResultArgs();

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new RestClient(baseUrl + "UserAuthentication/Authenticate");
            var request = new RestRequest("", RestSharp.Method.Post);
            request.AddHeader("Accept", "application/json");
            var body = new
            {
                customerName = userCredential.CustomerName,
                password = userCredential.Password
            };
            request.AddJsonBody(body);
            RestResponse restresponse = client.Execute(request);
            if (restresponse != null && !string.IsNullOrEmpty(restresponse.Content))
            {
                result = JsonConvert.DeserializeObject<AuthUserResultArgs>(restresponse.Content);

                if (result.UserDetails != null)
                {
                    if (result.UserDetails.CustomerId > 0)
                    {
                        HttpContext.Session.SetString("x", result.UserDetails.CustomerName);
                        HttpContext.Session.SetString("Token", result.JWTToken);
                        result.StatusCode = 200;
                    }
                    else
                    {
                        result.StatusCode = 204;
                    }
                }
                else
                {
                    result.StatusCode = 204;
                }
            }






            return result;
        }

    }
}


    

