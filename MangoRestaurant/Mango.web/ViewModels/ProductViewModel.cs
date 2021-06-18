using mango.web.Controllers;
using mango.web.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Categories = Enumerable.Empty<CategoryDto>();
        }
        [Required(ErrorMessage ="Category Is Mandatory")]
        [Remote(action:nameof(ProductController.VerifyCategory),controller:"Product")]
        public int Category { get; set; }
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Product name is mandatory")]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [Range(minimum:10,maximum:1000,ErrorMessage ="Price should be b/w 10$ and 1000$")]
        public double Price { get; set; }
        public string Description { get; set; }
        [Display(Name="Image")]
        public IFormFile Image { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
