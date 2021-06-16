using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.contract.dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public String Description { get; set; }
        public CategoryDto Category { get; set; }
        public String ImageUrl { get; set; }
    }
}
