using AutoMapper;
using mango.infrastructure.boilerplate.contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.infrastructure.boilerplate.managers
{
    public class DefaultAutoMapperManager : IApplicationManager<DefaultAutoMapperManager>
    {
        public virtual void ConfigureService(IServiceCollection services) { 
        }
    }
}
