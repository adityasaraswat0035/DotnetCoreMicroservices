using mango.infrastructure.boilerplate.managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.shopping.cart.api.ConfigurationManagers
{
    public class ShoppingCartApiAuthorizationManager : DefaultAuthorizationManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("mango", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "mango");
                });
            });
        }
    }
}
