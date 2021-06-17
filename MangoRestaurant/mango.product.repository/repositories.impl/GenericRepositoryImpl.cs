using mango.product.repository.DbContexts;
using mango.product.repository.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.repository.repositories.impl
{
    public class GenericRepositoryImpl<T, K> : GenericRepository<T, K> where T : BaseEntity<K>
    {
        private readonly ProductDbContext applicationDbContext;
        private DbSet<T> entities;
        public GenericRepositoryImpl(ProductDbContext productDbContext)
        {
            this.applicationDbContext = productDbContext;
            this.entities = productDbContext.Set<T>();
        }
        public async Task DeleteAsync(K key)
        {
            var item = await entities.FindAsync(key);
            if (item != null)
            {
                applicationDbContext.Remove(item);
                applicationDbContext.SaveChanges();
            }
        }
        public async Task<IEnumerable<T>> GetAsync()
        {
            return await entities.ToListAsync();
        }

        public Task<T> GetAsync(K key)
        {
            throw new NotImplementedException();
        }

        public async Task<T> SaveAsync(T item)
        {
            if (!default(K).Equals(item.Id))
            {
                entities.Update(item);
            }
            else
            {
                entities.Add(item);
            }
            await applicationDbContext.SaveChangesAsync();
            return item;
        }
    }
}
