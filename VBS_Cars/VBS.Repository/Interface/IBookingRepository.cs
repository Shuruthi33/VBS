using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models.Output;

namespace VBS.Repository.Interface
{
    public interface IBookingRepository
    {
        Task<BookingDetailsResult> GetBookingDetailsAsync();
        Task<BookingDTO> GetBookingDetailsByIdAsync(int Id);
        Task<int> SaveBookingDetailsAsync(BookingDTO bookingDTO);
        Task<Int16> DeleteBookingDetailsAsync(Int64 Id);
    }
}
