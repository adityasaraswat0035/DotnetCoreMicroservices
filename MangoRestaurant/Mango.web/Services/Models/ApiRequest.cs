using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static mango.web.Configuration.Services;

namespace mango.web.Services.Models
{
    public class ApiRequest
    {
        public String Url { get; set; }
        public RequestType Type { get; set; } = RequestType.GET;
        public Object Body { get; set; }
        public String AccessToken { get; set; }
    }
}
