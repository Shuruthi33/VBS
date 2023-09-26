using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;

namespace VBS.Models.Output
{
    public class UserDetailsResult
    {
        public int StatusCode { get; set; }
       
        public object? ResultData { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public UserDetailsDTO? UserDetails { get; set; }
        public List<UserDetailsResponseDTO>? UserDetailsList { get; set; }

    }

    public class UserDetailsResponseDTO
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? RoleName { get; set; }
        public string? ImagePath { get; set; }
    }
  


}
