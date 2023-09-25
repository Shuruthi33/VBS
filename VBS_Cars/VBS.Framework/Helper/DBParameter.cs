using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Framework.Helper
{
    public static class DBParameter
    {
        public static class UserDetails
        {
            public const string CustomerId = nameof(CustomerId);
            public const string CustomerName = nameof(CustomerName);
            public const string Password = nameof(Password);
            public const string Email = nameof(Email);
            public const string Address = nameof(Address);
            public const string PhoneNo = nameof(PhoneNo);
            public const string RoleId = nameof(RoleId);
            public const string ImagePath = nameof(ImagePath);
        }

        public static class VehicleDetails
        {
            public const string VehicleId = nameof(VehicleId);
            public const string Make = nameof(Make);
            public const string Model = nameof(Model);
            public const string Year = nameof(Year);
            public const string Price = nameof(Price);
            public const string Mileage = nameof(Mileage);
            public const string LicensePlate = nameof(LicensePlate);
            public const string Colour = nameof(Colour);
            public const string VIN = nameof(VIN);
            public const string EngineType = nameof(EngineType);
            public const string EngineSize = nameof(EngineSize);
            public const string FuelType = nameof(FuelType);
            public const string FuelTank = nameof(FuelTank);
            public const string SeatingCapacity = nameof(SeatingCapacity);
            public const string Condition = nameof(Condition);
            public const string Features = nameof(Features);
            public const string VersionName = nameof(VersionName);
            public const string ExShowroomPrice = nameof(ExShowroomPrice);
            public const string RTO = nameof(RTO);
            public const string Insurance = nameof(Insurance);
            public const string ImageURLs = nameof(ImageURLs);
            public const string VideoURLs = nameof(VideoURLs);
            public const string Availability = nameof(Availability);
        }
    }
}
