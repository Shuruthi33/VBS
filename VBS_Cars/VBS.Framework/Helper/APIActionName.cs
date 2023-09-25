using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Framework.Helper
{
    public class APIActionName
    {
        public static class Login
        {
            public const string Authenticate = nameof(Authenticate);
            public const string Logout = nameof(Logout);

        }

        public static class UserDetail
        {
            public const string GetUserDetailsAsync = nameof(GetUserDetailsAsync);
            public const string GetUserDetailsByIdAsync = nameof(GetUserDetailsByIdAsync);
            public const string SaveUserDetailsAsync = nameof(SaveUserDetailsAsync);
            public const string DeleteUserDetailsAsync = nameof(DeleteUserDetailsAsync);
        }

        public static class  VehicleDetails
        {
            public const string GetVehicleDetailsAsync = nameof(GetVehicleDetailsAsync);
            public const string GetVehicleDetailsByIdAsync = nameof(GetVehicleDetailsByIdAsync);
            public const string SaveVehicleDetailsAsync = nameof(SaveVehicleDetailsAsync);
            public const string DeleteVehicleDetailsAsync = nameof(DeleteVehicleDetailsAsync);
        }

        public static class BookingDetails
        {
            public const string GetBookingDetailsAsync = nameof(GetBookingDetailsAsync);
            public const string GetBookingDetailsByIdAsync = nameof(GetBookingDetailsByIdAsync);
            public const string SaveBookingDetailsAsync = nameof(SaveBookingDetailsAsync);
            public const string DeleteBookingDetailsAsync = nameof(DeleteBookingDetailsAsync);
        }

        public static class FeedbackDetails
        {
            public const string GetFeedbackDetailsAsync = nameof(GetFeedbackDetailsAsync);
            public const string GetFeedbackDetailsByIdAsync = nameof(GetFeedbackDetailsByIdAsync);
            public const string SaveFeedbackDetailsAsync = nameof(SaveFeedbackDetailsAsync);
            public const string DeleteFeedbackDetailsAsync = nameof(DeleteFeedbackDetailsAsync);
        }
    }
}
