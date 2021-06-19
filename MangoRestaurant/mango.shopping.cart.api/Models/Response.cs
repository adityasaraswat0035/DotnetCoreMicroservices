using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.shopping.cart.api.Models
{
    public class Response<T>
    {
        private static Dictionary<string, List<string>> empty = new Dictionary<string, List<string>>();
        public IDictionary<string, List<string>> ErrorMessages { get; set; } = empty;
        public T Result { get; set; }
    }
}
