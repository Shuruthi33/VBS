using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Framework.Helper
{
    public static class DBParameter
    {
        public static class UserDetails
        {
            public const string CustomerId = nameof(CustomerId);
            public const string CustomerName = nameof(CustomerName);
            public const string Password = nameof(Password);
            public const string Email = nameof(Email);
            public const string Address = nameof(Address);
            public const string PhoneNo = nameof(PhoneNo);
            public const string RoleId = nameof(RoleId);
            public const string ImagePath = nameof(ImagePath);
        }
    }
}
