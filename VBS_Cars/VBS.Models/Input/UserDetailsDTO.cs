using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models.Input
{
    public class UserCredential
    {
        public string? CustomerName { get; set; }
        public string? Password { get; set; }
    }

    public class UserDetailsDTO
    {
        public int? CustomerId { get; set; } 
        public string? CustomerName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public int? RoleId { get; set; }
        public string? ImagePath { get; set; }
    }

  
    public class VehicleDetailsDTO
    {
        public int VehicleId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal Mileage { get; set; }
        public string? LicensePlate { get; set; }
        public string? Colour { get; set; }
        public string? VIN { get; set; }
        public string? EngineType { get; set; }
        public decimal EngineSize { get; set; }
        public string? FuelType { get; set; }
        public decimal FuelTank { get; set; }
        public int SeatingCapacity { get; set; }
        public string? Condition { get; set; }
        public string? Features { get; set; }
        public string? VersionName { get; set; }
        public decimal ExShowroomPrice { get; set; }
        public decimal RTO { get; set; }
        public decimal Insurance { get; set; }
        public string? ImageURLs { get; set; }
        public string? VideoURLs { get; set; }
        public bool Availability { get; set; }
    }

    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool CancelBooking { get; set; }
        public string? ReturnStatus { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class FeedbackDTO
    {
        public int FeedbackId { get; set; }
        public int BookingId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
  
    }


}
