using mango.product.repository.DbContexts;
using mango.product.repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.repository.repositories.impl
{
    public class ProductRepositoryImpl : ProductRepository
    {
        private readonly ProductDbContext productDbContext;

        public ProductRepositoryImpl(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        public async Task DeleteProductAsync(int productId)
        {
            var product = await productDbContext.Products.FindAsync(productId);
            if (product != null)
            {
                productDbContext.Remove(product);
                productDbContext.SaveChanges();
            }
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var product = await productDbContext.Products.FindAsync(productId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await productDbContext.Products.ToListAsync();
        }

        public async Task<Product> SaveProductAsync(Product product)
        {
            if (product.Id > 0)
            {
                productDbContext.Products.Update(product);
            }
            else
            {
                productDbContext.Products.Add(product);
            }
            await productDbContext.SaveChangesAsync();
            return product;
        }
    }
}
