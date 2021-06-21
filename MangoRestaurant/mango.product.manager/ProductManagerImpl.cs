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
    public class ProductManagerImpl : ProductManager
    {
        private readonly ProductRepository productRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public ProductManagerImpl(ProductRepository productRepository, CategoryRepository categoryRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto> DeleteProductAsync(int productId)
        {
            var product= await productRepository.DeleteAsync(productId);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<Optional<ProductDto>> GetProductAsync(int productId)
        {
            var product = await productRepository.GetAsync(productId);
            if (product != null)
                return Optional<ProductDto>.Some(mapper.Map<ProductDto>(product));
            else
                return Optional<ProductDto>.None();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var product = await productRepository.GetAsync();
            return mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<ProductDto> SaveProductAsync(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            var category = await categoryRepository.GetAsync(product.Category.Id);
            if (category != null)
            {
                product.Category = category;
            }
            await productRepository.SaveAsync(product);
            return mapper.Map<ProductDto>(product);
        }
    }
}
