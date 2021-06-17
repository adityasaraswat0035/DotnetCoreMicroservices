﻿using mango.product.api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace mango.product.api.Filters
{
    public class ErrorFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment environment;

        public ErrorFilter(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        //log and rethrow
        public void OnException(ExceptionContext context)
        {
            if (environment.IsDevelopment())
            {
                context.Result = new ObjectResult(context.Exception) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
            else
            {
                //can do for validation also
                context.Result = new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
