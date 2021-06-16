using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.Models
{
    public class Response<T>
    {
        public IEnumerable<KeyValuePair<String, IEnumerable<String>>> ErrorMessages { get; set; } = Enumerable.Empty<KeyValuePair<String, IEnumerable<String>>>();
        public T Result { get; set; }
    }
}
