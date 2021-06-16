using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.infrastructure.boilerplate.contracts
{
    public interface IApplicationManager
    {
        public virtual void ConfigureService(IServiceCollection services) { }
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env) { }
    }
    public interface IApplicationManager<T> : IApplicationManager
        where T : IApplicationManager<T>, new()
    {

    }
}
