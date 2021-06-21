using mango.integration.kafka.Configuration;
using mango.integration.kafka.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka
{
    public static class KafkaServicesRegisteration
    {
        public static void AddKafkaServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<KafkaProducerConfiguration>(instance => configuration.GetSection("KafkaProducerConfiguration").Bind(instance));
            services.Configure<KafkaConsumerConfiguration>(instance=>configuration.GetSection("KafkaConsumerConfiguration").Bind(instance));
            services.AddSingleton<IKafkaProducer, KafkaProducer>();
        }
    }
}
