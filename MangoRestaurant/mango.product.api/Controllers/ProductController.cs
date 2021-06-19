using mango.infrstructure.common.Wrappers;
using mango.product.api.Controllers.Base;
using mango.product.api.Models;
using mango.product.contract.contracts;
using mango.product.contract.dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ApiBaseController
    {
        private ProductManager productManager;
        public ProductController(ProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productManager.GetProductsAsync().ConfigureAwait(false));
        }
        [HttpGet]
        [Route("{productId:int}")]
        public async Task<IActionResult> Get(int productId)
        {
            return OptionalOK(await productManager.GetProductAsync(productId).ConfigureAwait(false));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            return Ok(await productManager.SaveProductAsync(productDto).ConfigureAwait(false));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            return Ok(await productManager.SaveProductAsync(productDto).ConfigureAwait(false));
        }
        [HttpDelete]
        [Route("{productId:int}")]
        public async Task<IActionResult> Delete(int productId)
        {
            return Ok(await productManager.DeleteProductAsync(productId).ConfigureAwait(false));
        }
    }
}
