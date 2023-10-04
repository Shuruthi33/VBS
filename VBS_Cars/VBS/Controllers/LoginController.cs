using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using VBS.Models;
using VBS.Models.Input;
using VBS.Models.Output;
using AuthUserResultArgs = VBS.Models.Output.UserDetailsResult;

namespace VBS.Controllers
{
    
    public class LoginController : Controller
    {
        public LoginController() {
        }
        public IActionResult Login()
        {
            return View();
        }
       
        public IActionResult Register()
        {
            return View();
        }
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(Models.UserCredential userCredential)
        {
            UserDetailsResult result = new UserDetailsResult();
            try
            {
                result = UserAuthentication(userCredential);

                if(result.StatusCode==200)
                {
                    return RedirectToAction("ViewVehicle", "Vehicle");
                }
                else
                {
                    ViewBag.message = "Faiied";

                    return View("Login");
                }
               
            }
            catch (Exception ex)
            {

            }

            return View("Login");
        }

        [HttpPost]
        [Route("UserAuthentication")]
        public UserDetailsResult UserAuthentication(Models.UserCredential userCredential)
        {
            var baseUrl = "https://localhost:7011/api";

            UserDetailsResult result = new UserDetailsResult();

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new RestClient(baseUrl + "/UserAuthentication/Authenticate");
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
                result = JsonConvert.DeserializeObject<UserDetailsResult>(restresponse.Content);

                if (result.UserDetails != null)
                {
                    if (result.UserDetails.CustomerId > 0)
                    {
                        HttpContext.Session.SetString("Name", result.UserDetails.CustomerName);
                        HttpContext.Session.SetInt32("CustomerId", (int)result.UserDetails.CustomerId);

                        if(result.UserDetails.JWTToken != null)
                        HttpContext.Session.SetString("Token", result.UserDetails.JWTToken);

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


    

