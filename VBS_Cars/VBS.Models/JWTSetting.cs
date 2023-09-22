using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models
{
    public class JWTSetting
    {
        public string SecurityKey { get; set; } = string.Empty;
        public string AllowOrigin { get; set; } = string.Empty;
    }
}
