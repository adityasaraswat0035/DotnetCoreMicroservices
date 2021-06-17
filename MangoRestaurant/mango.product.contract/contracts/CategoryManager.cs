﻿using mango.infrstructure.common.Wrappers;
using mango.product.contract.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.contract.contracts
{
    public interface CategoryManager
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<Optional<CategoryDto>> GetCategoryAsync(int categoryId);

        Task<CategoryDto> SaveCategoryAsync(CategoryDto categoryDto);

        Task DeleteCategoryAsync(int categoryId);
    }
}
