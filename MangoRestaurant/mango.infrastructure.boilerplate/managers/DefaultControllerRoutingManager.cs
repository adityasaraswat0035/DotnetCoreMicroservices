using mango.infrastructure.boilerplate.contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.infrastructure.boilerplate.managers
{
    public class DefaultControllerRoutingManager : IApplicationManager<DefaultSwaggerManager>
    {
        public virtual void ConfigureService(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options=> {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
