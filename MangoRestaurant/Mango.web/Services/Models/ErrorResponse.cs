using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Services.Models
{
    public class ErrorResponse : Exception
    {
        public IDictionary<string, List<string>> Errors { get; }
        public ErrorResponse(IDictionary<string, List<string>> errors):base()
        {
            Errors = errors;
        }
        public ErrorResponse(IDictionary<string, List<string>> errors, String message):base(message)
        {
            Errors = errors;
        }
        public ErrorResponse(IDictionary<string, List<string>> errors, string? message, Exception? innerException):base(message, innerException)
        {
            Errors = errors;
        }
       
    }
}
