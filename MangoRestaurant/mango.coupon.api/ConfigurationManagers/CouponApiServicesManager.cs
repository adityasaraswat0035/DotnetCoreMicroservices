using mango.infrastructure.boilerplate.managers;
using Microsoft.Extensions.DependencyInjection;

namespace mango.coupon.api.ConfigurationManagers
{
    public class CouponApiServicesManager : DefaultApplicationServicesManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            //services.AddScoped<ProductManager, ProductManagerImpl>();
            //services.AddScoped<CategoryManager, CategoryManagerImpl>();
            //services.AddScoped<CategoryRepository, CategoryRepositoryImpl>();
            //services.AddScoped<ProductRepository, ProductRepositoryImpl>();

        }
    }
}
