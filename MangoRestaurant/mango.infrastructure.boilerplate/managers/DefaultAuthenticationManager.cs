using mango.infrastructure.boilerplate.contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.infrastructure.boilerplate.managers
{
    public class DefaultAuthenticationManager: IApplicationManager<DefaultAuthenticationManager>
    {
        public IConfiguration Configuration { get; set; }
        public virtual void ConfigureService(IServiceCollection services)
        {

        }
    }
}
