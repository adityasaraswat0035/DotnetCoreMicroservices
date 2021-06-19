﻿using mango.infrastructure.boilerplate.managers;
using mango.shopping.cart.api.Infrastructure.Database;
using mango.shopping.cart.contracts.contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace mango.shopping.cart.api.ConfigurationManagers
{
    public class ShoppingCartDatabaseSeedManager : DefaultDatabaseSeedManager
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
