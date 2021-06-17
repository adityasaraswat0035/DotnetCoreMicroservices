using mango.infrastructure.boilerplate.managers;
using mango.product.api.Infrastructure.Database;
using mango.product.contract.contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.ConfigurationManagers
{
    public class ProductDatabaseSeedManager : DefaultDatabaseSeedManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<DbInitializer, DbInitializerImpl>();
        }
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    var dbInitializer = scope.ServiceProvider.GetService<DbInitializer>();
                    dbInitializer.Initialize();
                    dbInitializer.SeedData();
                }
            }
        }
    }
}
