using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Services.Contracts
{
    public interface ICategoryService:IBaseService
    {
        Task<T> GetCategoryAsync<T>();
        Task<T> GetCategoryAsync<T>(int categoryId);
    }
}
