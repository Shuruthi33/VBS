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
        Task<UserDetailsResult> GetUserDetailsAsync();
        Task<UserDetailsDTO> GetUserDetailsByIdAsync(int Id);
        Task<int> SaveUserDetailsAsync(UserDetailsDTO userDetailsDTO);
        Task<Int16> DeleteUserDetailsAsync(Int64 Id);
    }
}
