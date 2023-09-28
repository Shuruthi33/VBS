using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models.Input
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DeliveryDate { get; set; } 
        public string? CancelBooking { get; set; }
        public string? ReturnStatus { get; set; }

    }
}
