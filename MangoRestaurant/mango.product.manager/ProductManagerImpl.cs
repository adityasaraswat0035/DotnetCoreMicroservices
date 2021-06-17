﻿using AutoMapper;
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
    public class ProductManagerImpl : ProductManager
    {
        private readonly GenericRepository<Product, int> productRepository;
        private readonly IMapper mapper;

        public ProductManagerImpl(GenericRepository<Product,int> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public Task DeleteProductAsync(int productId)
        {
            return productRepository.DeleteAsync(productId);
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
            var savedProduct = await productRepository.SaveAsync(product);
            return mapper.Map<ProductDto>(savedProduct);
        }
    }
}
