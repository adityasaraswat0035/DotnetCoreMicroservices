using mango.product.api.Controllers.Base;
using mango.product.contract.contracts;
using mango.product.contract.dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ApiBaseController
    {
        private CategoryManager categoryManager;
        public CategoryController(CategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoryManager.GetCategoriesAsync().ConfigureAwait(false));
        }
        [HttpGet]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            return OptionalOK(await categoryManager.GetCategoryAsync(categoryId).ConfigureAwait(false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto categoryDto)
        {
            return Ok(await categoryManager.SaveCategoryAsync(categoryDto).ConfigureAwait(false));
        }
        [HttpDelete]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            await categoryManager.DeleteCategoryAsync(categoryId).ConfigureAwait(false);
            return NoContent();
        }
    }
}
