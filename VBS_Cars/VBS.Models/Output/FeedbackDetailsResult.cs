using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;

namespace VBS.Models.Output
{
    public class FeedbackDetailsResult
    {
        public int StatusCode { get; set; }
        public string? JWTToken { get; set; }
        public object? ResultData { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public FeedbackDTO? FeedbackDetails { get; set; }
        public List<FeedbackResponseDTO>? FeedbackDetailsList { get; set; }
    }

       public class FeedbackResponseDTO
       {
        public int FeedbackId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int VehicleId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
       }
}
