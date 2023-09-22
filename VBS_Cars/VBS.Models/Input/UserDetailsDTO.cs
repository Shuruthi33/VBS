using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models.Input
{
    public class UserCredential
    {
        public string? CustomerName { get; set; }
        public string? Password { get; set; }
    }

    public class UserDetailsDTO
    {
        public int? CustomerId { get; set; } 
        public string? CustomerName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public int? RoleId { get; set; }
        public string? ImagePath { get; set; }

       // public ClaimsIdentity? UserName { get; set; }
    }

}
