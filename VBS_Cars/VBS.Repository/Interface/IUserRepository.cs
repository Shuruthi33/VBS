using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models.Output;

namespace VBS.Repository.Interface
{
    public interface IUserRepository
    {
        Task<UserDetailsResult> GetUserDetailsAsync();
        Task<UserDetailsResponseDTO> GetUserDetailsByIdAsync(int Id);
        Task<int> SaveUserDetailsAsync(UserDetailsDTO userDetailsDTO);
        Task<Int16> DeleteUserDetailsAsync(Int64 Id);

     
    }
}
