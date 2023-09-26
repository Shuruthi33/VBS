using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;

namespace VBS.Models.Output
{
   
       public class VehicleDetailsResult
       {
           public int StatusCode { get; set; }
           public string? JWTToken { get; set; }
           public object? ResultData { get; set; }
           public string StatusMessage { get; set; } = string.Empty;

           public VehicleDetailsDTO? VehicleDetails { get; set; }
           public List<VehicleDetailsDTO>? VehicleDetailsList { get; set; }
       
       }
}
