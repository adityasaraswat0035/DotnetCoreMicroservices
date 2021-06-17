using mango.web.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Contracts
{
    public interface IBaseService:IDisposable
    {
        Task<T> SendAsync<T>(ApiRequest request);
    }
}
