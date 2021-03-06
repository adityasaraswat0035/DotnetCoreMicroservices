using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.order.api.Messages
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
