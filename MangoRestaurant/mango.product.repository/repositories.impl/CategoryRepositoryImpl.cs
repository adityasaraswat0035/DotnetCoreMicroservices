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
    public class CategoryRepositoryImpl : CategoryRepository
    {
        private readonly ProductDbContext productDbContext;

        public CategoryRepositoryImpl(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        public async Task DeleteAsync(int categoryId)
        {
            var item = await productDbContext.Categories.FindAsync(categoryId);
            productDbContext.Remove(item);
            await productDbContext.SaveChangesAsync();

        }
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await productDbContext.Categories.Include(x => x.Products).ToListAsync();
        }

        public async Task<Category> GetAsync(int categoryId)
        {
            var item = await productDbContext.Categories.FindAsync(categoryId);
            await productDbContext.Entry(item).Collection(x => x.Products).LoadAsync();
            return item;
        }

        public async Task<Category> SaveAsync(Category category)
        {
            productDbContext.Categories.Add(category);
            await productDbContext.SaveChangesAsync();
            return category;
        }
    }
}
