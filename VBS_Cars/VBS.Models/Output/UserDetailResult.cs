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
		public string? JWTToken { get; set; }
		public object? ResultData { get; set; }
		public string StatusMessage { get; set; } = string.Empty;

		public UserDetailsDTO? UserDetails { get; set; }
		public List<UserDetailsDTO>? UserDetailsList { get; set; }
		
	}
    public class EmailDetailsResult
    {
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        
    }




}
