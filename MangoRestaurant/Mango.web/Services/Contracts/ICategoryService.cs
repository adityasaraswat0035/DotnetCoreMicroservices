using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Services.Contracts
{
    public interface ICategoryService:IBaseService
    {
        Task<T> GetCategoryAsync<T>(string token);
        Task<T> GetCategoryAsync<T>(int categoryId, string token);
    }
}
