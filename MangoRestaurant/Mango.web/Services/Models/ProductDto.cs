using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.web.Services.Models
{
    public class ProductDto
    {
        public ProductDto()
        {
            Count = 1;
        }
        [Range(minimum:1, maximum:10,ErrorMessage ="Allowed range is b/w 1 and 10")]
        public int Count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
