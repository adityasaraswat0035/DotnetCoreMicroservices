using mango.infrstructure.common.Wrappers;
using mango.shopping.cart.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace mango.shopping.cart.api.Controllers.Base
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public OkObjectResult Ok<T>(IEnumerable<T> result)
        {
            var response = new Response<IEnumerable<T>>() { Result = result };
            return base.Ok(response);
        }
        public OkObjectResult Ok<T>(T result)
        {
            return base.Ok(new Response<T>() { Result = result });
        }
        public IActionResult OptionalOK<T>(Optional<T> result)
        {
            if (result.IsEmpty)
                return base.NotFound();
            else
                return base.Ok(new Response<T>() { Result = result.Get() });
        }
    }
}
