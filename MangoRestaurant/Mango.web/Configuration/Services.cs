using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Configuration
{
    public class ServicesUrl
    {
        public String ProductApiBase { get; set; }
    }
    public enum RequestType
    {
        GET,
        PUT,
        POST,
        DELETE
    }
}
