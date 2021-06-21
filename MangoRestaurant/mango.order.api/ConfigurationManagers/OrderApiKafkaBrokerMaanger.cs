using mango.infrastructure.boilerplate.managers;
using mango.integration.kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mango.shopping.cart.api.ConfigurationManagers
{
    public class OrderApiKafkaBrokerMaanger : DefaultMessageBrokerManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddKafkaServices(Configuration);
        }
    }
}
