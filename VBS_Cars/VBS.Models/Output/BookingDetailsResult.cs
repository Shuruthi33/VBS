using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;

namespace VBS.Models.Output
{
    public class BookingDetailsResult
    {
        public int StatusCode { get; set; }
        public string? JWTToken { get; set; }
        public object? ResultData { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public BookingDTO? BookingDetails { get; set; }
        public List<BookingDetailsResponseDTO>? BookingDetailsList { get; set; }
    }


    public class BookingDetailsResponseDTO
    {
        public int BookingId { get; set; }
        public string? CustomerName { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? CancelBooking { get; set; }
        public string? ReturnStatus { get; set; }
       

    }

}
