using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka.Configuration
{
    public class KafkaProducerConfiguration
    {
        public String BootstrapServers { get; set; }

        public ProducerConfig Get()
        {
            return new ProducerConfig() { BootstrapServers = BootstrapServers };
        }
    }
}
