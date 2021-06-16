using mango.infrastructure.boilerplate.contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace mango.infrastructure.boilerplate.managers
{
    public class DefaultDbContextManager : IApplicationManager<DefaultDbContextManager>
    {
        public IConfiguration Configuration { get; set; }
        public virtual void ConfigureService(IServiceCollection services)
        {
        }
    }
}
