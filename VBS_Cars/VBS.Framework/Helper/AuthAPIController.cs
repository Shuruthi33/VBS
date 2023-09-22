using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Framework.Helper
{
    public class AuthAPIController
    {
        public static class InputType
        {
            public const string ApplicationJson = "application/json";
            public const string Text = "Text";
        }

        public static class Property
        {
            public const string APIController = "api/[controller]/[action]";
            public const string AllowOrigin = "AllowOrigin";
        }
    }
}
