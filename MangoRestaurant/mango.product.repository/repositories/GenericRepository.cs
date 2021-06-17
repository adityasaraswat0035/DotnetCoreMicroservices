using mango.product.repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.repository.repositories
{
    public interface GenericRepository<T,K> where T:BaseEntity<K>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(K key);

        Task<T> SaveAsync(T item);

        Task DeleteAsync(K key);
    }
}
