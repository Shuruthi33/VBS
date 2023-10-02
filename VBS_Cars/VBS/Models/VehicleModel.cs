using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VBS.Models
{
    public class VehicleModel
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

        [Display(Name = "Image Path")]
        public string? ImageURLs { get; set; }
        public string? VideoURLs { get; set; }
        public bool Availability { get; set; }
    }
}
