using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using VBS.Models;
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
       
        public IActionResult Register()
        {
            return View();
        }
        //[Route("Authenticate")]
        //public async Task<IActionResult> Authenticate(Models.UserCredential userCredential)
        //{
        //    AuthUserResultArgs result = new AuthUserResultArgs();
        //    try
        //    {
        //        result = UserAuthentication(userCredential);
        //    }
        //    catch (Exception ex)
        //    {

        //    }

          //  return Ok(result);
        //}
        [HttpPost]
        [Route("Authenticate")]
        public RestResponse Authenticate(Models.UserCredential obj)
        {

            var options = new RestClientOptions("https://localhost:7011")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/UserAuthentication/Authenticate", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                UserName = obj.CustomerName,
               
                Password = obj.Password,
            };
            request.AddJsonBody(body);

            //  request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string str = response.Content.ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            //  setting variables in the[Session]
            if (!string.IsNullOrEmpty(response.Content))
            {
                var getData = JsonConvert.DeserializeObject<ReturnSession>(str);
                
                var CustomerId = getData.resultData.CustomerId;
                var CustomerName = getData.resultData.CustomerName;
                var Email = getData.resultData.Email;
                var PhoneNo = getData.resultData.PhoneNo;
                var Address = getData.resultData.Address;
                var Password = getData.resultData.Password;
                var RoleId = getData.resultData.RoleId;

                if (!string.IsNullOrEmpty(Email))
                {
                    HttpContext.Session.SetString("EMAIL", Email);

                }
                if (!string.IsNullOrEmpty(CustomerName))
                {
                    HttpContext.Session.SetString("UNAME", CustomerName);
                }
                if (!string.IsNullOrEmpty(Password))
                {
                    HttpContext.Session.SetString("UPASSWORD", Password);
                }
                if (!string.IsNullOrEmpty(PhoneNo))
                {
                    HttpContext.Session.SetString("UADDRESS", Address);
                }
                if (!string.IsNullOrEmpty(PhoneNo))
                {
                    HttpContext.Session.SetString("UPHONENO", PhoneNo);
                }

                //var Url = _configuration["ApibaseUrlUsers"];
               // var AdminUrl = _configuration["ApibaseUrlAdmin"];


                

                HttpContext.Session.SetInt32("UID", CustomerId);
                HttpContext.Session.SetInt32("UROLE", RoleId);
               // HttpContext.Session.SetInt32("USELLER", userIsSeller);

            }
            return response;

        }
        //[HttpPost]
        //[Route("UserAuthentication")]
        //public AuthUserResultArgs UserAuthentication(UserCredential userCredential)
        //{
        //    var baseUrl = "https://localhost:7011/api/";

        //    AuthUserResultArgs result = new AuthUserResultArgs();

        //    ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //    var client = new RestClient(baseUrl + "/Login/Authenticate");
        //    var request = new RestRequest("", RestSharp.Method.Post);
        //    request.AddHeader("Accept", "application/json");
        //    var body = new
        //    {
        //        customerName = userCredential.CustomerName,
        //        password = userCredential.Password
        //    };
        //    request.AddJsonBody(body);
        //    RestResponse restresponse = client.Execute(request);

        //    string src = 
        //    if (restresponse != null && !string.IsNullOrEmpty(restresponse.Content))
        //    {
        //        result = JsonConvert.DeserializeObject<ReturnSession>(restresponse.Content);

        //        if (result.UserDetails != null)
        //        {
        //            if (result.UserDetails.CustomerId > 0)
        //            {
        //                HttpContext.Session.SetString("x", result.UserDetails.CustomerName);
        //                HttpContext.Session.SetString("Token", result.JWTToken);
        //                result.StatusCode = 200;
        //            }
        //            else
        //            {
        //                result.StatusCode = 204;
        //            }
        //        }
        //        else
        //        {
        //            result.StatusCode = 204;
        //        }
        //    }
        // return result;
        //}

    }
}


    

