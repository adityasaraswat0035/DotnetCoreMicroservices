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
        public async Task<Product> DeleteAsync(int productId)
        {
            var product = await productDbContext.Products.FindAsync(productId);
            if (product != null)
            {
                productDbContext.Remove(product);
                productDbContext.SaveChanges();
            }
            return product;
        }

        public async Task<Product> GetAsync(int productId)
        {
            var product = await productDbContext.Products.FindAsync(productId);
            await productDbContext.Entry(product).Reference(x => x.Category).LoadAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await productDbContext.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> SaveAsync(Product product)
        {
            try
            {
                if (product.Id > 0)
                {
                    var entity = productDbContext.Products.Find(product.Id);
                    entity.Category.Id = product.Category.Id;
                    entity.Category.Name = product.Category.Name;
                    entity.Id = product.Id;
                    entity.Name = product.Name;
                    entity.Price = product.Price;
                    entity.ImageUrl = product.ImageUrl;
                    productDbContext.Products.Update(entity);
                }
                else
                {
                    productDbContext.Products.Add(product);
                }
                await productDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
            return product;
        }
    }
}
