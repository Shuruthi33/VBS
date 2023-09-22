using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models;
using VBS.Models.Input;

namespace VBS.Service.Interface
{
    public interface IUserService
    {
        Task<ResultDataArgs> GetUserDetailsAsync();

        Task<ResultDataArgs> GetUserDetailsByIdAsync(int Id);
        Task<ResultDataArgs> SaveUserDetailsAsync(UserDetailsDTO userDetailsDTO);

        Task<ResultDataArgs> DeleteUserDetailsAsync(Int64 Id);

    }
}
