using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models.Output;

namespace VBS.Repository.Interface
{
    public interface IAuthenticateRepository
    {
        Task<UserDetailsResult> AuthenticateUserAsync(UserCredential user);
    }
}
