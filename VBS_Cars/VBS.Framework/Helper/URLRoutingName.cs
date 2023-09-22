using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Framework.Helper
{
    public class URLRoutingName
    {
        public static class Login
        {
            public const string Authenticate = "authenticate";
            public const string Logout = "logout";
        }

        public static class Authentication
        {
            public const string Authenticate = "authenticate";
            public const string ForgetPassword = "forget-password";

            public const string Signup = "signup";
            public const string Login = "login";
            public const string LogOut = "logout";
        }
    }
}
