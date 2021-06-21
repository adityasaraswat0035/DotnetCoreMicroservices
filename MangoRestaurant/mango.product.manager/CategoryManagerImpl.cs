using AutoMapper;
using mango.infrstructure.common.Wrappers;
using mango.product.contracts.contracts;
using mango.product.contracts.dtos;
using mango.product.repository.Entities;
using mango.product.repository.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.manager
{
    public class CategoryManagerImpl : CategoryManager
    {
        private readonly CategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryManagerImpl(CategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public Task DeleteCategoryAsync(int categoryId)
        {
            return categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await categoryRepository.GetAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<Optional<CategoryDto>> GetCategoryAsync(int categoryId)
        {
            var category = await categoryRepository.GetAsync(categoryId);
            if (category != null)
                return Optional<CategoryDto>.Some(mapper.Map<CategoryDto>(category));
            else
                return Optional<CategoryDto>.None();
        }

        public async Task<CategoryDto> SaveCategoryAsync(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            var savedProduct = await categoryRepository.SaveAsync(category);
            return mapper.Map<CategoryDto>(savedProduct);
        }
    }
}
