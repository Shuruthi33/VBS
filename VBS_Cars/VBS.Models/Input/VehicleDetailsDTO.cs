using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models.Input
{
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
}
