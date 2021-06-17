using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.Models
{
    public class Response<T>
    {
        private static Dictionary<String,List<String>> empty=new Dictionary<String, List<String>>();
        public IDictionary<String, List<String>> ErrorMessages { get; set; } = empty;
        public T Result { get; set; }
    }
}
