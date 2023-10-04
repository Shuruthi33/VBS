using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************************************************************************************************
 * Created by       : Shuruthi
 * Created On       : 09/22/2023
 *
 * Reviewed By      :
 * Reviewed On      :
 *
 * Purpose          : This class provides constant strings representing stored procedure names for various
 *                    database operations related to customer, vehicle, booking, and feedback details.
 *                    It serves as a central repository for storing and referencing these procedure names
 *                    throughout the application.
 ***********************************************************************************************************/

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
        public class BookingDetails
        {
            public const string GetBookingInfo = "GetBookingInfo";
            public const string GetBookingById = "GetBookingById";
            public const string SaveBooking = "SaveBooking";
            public const string DeleteBooking = "DeleteBooking";

        }
        public class FeedbackDetails
        {
            public const string GetFeedback = "GetFeedback";
            public const string GetFeedbackById = "GetFeedbackById";
            public const string SaveFeedback = "SaveFeedback";
            public const string DeleteFeedback = "DeleteFeedback";

        }
    }
}
