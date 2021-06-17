using AutoMapper.Configuration;
using mango.infrastructure.boilerplate.contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.infrastructure.boilerplate.managers
{
    public class DefaultDatabaseSeedManager: IApplicationManager<DefaultGlobalExceptionManager>
    {
        public IConfiguration Configuration { get; set; }
        public virtual void ConfigureService(IServiceCollection services)
        {

        }
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
        }
    }
}
