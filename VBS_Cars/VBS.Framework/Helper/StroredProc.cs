using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Framework.Helper
{
    public class StroredProc
    {
        public class UserDetails
        {

            public const string GetCustomerInfo = "GetCustomerInfo";
            public const string GetCustomerById = "GetCustomerById";
            public const string SaveCustomer = "SaveCustomer";
            public const string DeleteCustomer = "DeleteCustomer";
        }
        public class VehicleDetails
        {
            public const string GetVehicleInfo = "GetVehicleInfo";
            public const string GetVehicleById = "GetVehicleById";
            public const string SaveVehicles = "SaveVehicles";
            public const string DeleteVehicle = "DeleteVehicle";

        }
    }
}
