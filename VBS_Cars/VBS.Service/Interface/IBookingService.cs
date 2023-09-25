using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models;

namespace VBS.Service.Interface
{
    public interface IBookingService
    {
        Task<ResultDataArgs> GetBookingDetailsAsync();

        Task<ResultDataArgs> GetBookingDetailsByIdAsync(int Id);
        Task<ResultDataArgs> SaveBookingDetailsAsync(BookingDTO bookingDTO);

        Task<ResultDataArgs> DeleteBookingDetailsAsync(Int64 Id);
    }
}
