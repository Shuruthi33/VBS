using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************************************************************************************************
 * Created by       : Shuruthi
 * Created On       : 09/22/2023
 *
 * Reviewed By      :
 * Reviewed On      :
 *
 * Purpose          : Common to use to Auth api controller
 ***********************************************************************************************************/


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
