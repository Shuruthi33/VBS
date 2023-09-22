using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models
{
    public  class ResultDataArgs
    {
        public Int64 StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public string? MessageTitle { get; set; }
        public object? ResultData { get; set; }
    }
}
