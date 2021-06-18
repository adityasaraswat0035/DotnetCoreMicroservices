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
        public async Task DeleteAsync(int productId)
        {
            var product = await productDbContext.Products.FindAsync(productId);
            if (product != null)
            {
                productDbContext.Remove(product);
                productDbContext.SaveChanges();
            }
        }

        public async Task<Product> GetAsync(int productId)
        {
            var product = await productDbContext.Products.FindAsync(productId);
            await productDbContext.Entry(product).Reference(x => x.Category).LoadAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await productDbContext.Products.Include(x=>x.Category).ToListAsync();
        }

        public async Task<Product> SaveAsync(Product product)
        {
            if (product.Id > 0)
            {
                productDbContext.Products.Update(product);
            }
            else
            {
                productDbContext.Products.Add(product);
            }
            try
            {

                await productDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            } return product;
        }
    }
}
