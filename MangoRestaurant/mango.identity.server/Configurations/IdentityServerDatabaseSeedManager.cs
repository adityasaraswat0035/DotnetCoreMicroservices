using mango.identity.server.Infrastructure.Database;
using mango.product.api.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace mango.product.api.ConfigurationManagers
{
    public static class IdentityServerDatabaseSeedManager
    {
        public static void AddDbIntializer(this IServiceCollection services)
        {
            services.AddScoped<DbInitializer, DbInitializerImpl>();
        }
        public static void UseDbIntializer(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
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
