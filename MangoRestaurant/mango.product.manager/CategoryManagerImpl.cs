using AutoMapper;
using mango.infrstructure.common.Wrappers;
using mango.product.contract.contracts;
using mango.product.contract.dtos;
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
        private readonly GenericRepository<Category, int> categoryRepository;
        private readonly IMapper mapper;
        private readonly GenericRepository<Product, int> productRepository;

        public CategoryManagerImpl(GenericRepository<Category, int> categoryRepository, IMapper mapper, GenericRepository<Product, int> productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.productRepository = productRepository;
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
