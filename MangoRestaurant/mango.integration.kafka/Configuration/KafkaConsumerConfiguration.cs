using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka.Configuration
{
    public class KafkaConsumerConfiguration
    {
        public String BootstrapServers { get; set; }
        public string GroupId { get; set; }
        public string AutoOffsetReset { get; set; }
        public string AutoCommit { get; set; } 
        public string AutoOffsetStore { get; set; }

        public ConsumerConfig Get()
        {
            var consumerConfig = new ConsumerConfig();
            consumerConfig.BootstrapServers = BootstrapServers;
            consumerConfig.GroupId = string.IsNullOrWhiteSpace(GroupId)? Assembly.GetEntryAssembly().FullName.Split(",")[0]:GroupId;
            consumerConfig.AutoOffsetReset = AutoOffsetReset.Equals("earliest", StringComparison.InvariantCultureIgnoreCase) ? Confluent.Kafka.AutoOffsetReset.Earliest : Confluent.Kafka.AutoOffsetReset.Latest;
            consumerConfig.EnableAutoCommit = AutoCommit.Equals("enabled", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            consumerConfig.EnableAutoOffsetStore = AutoOffsetStore.Equals("enabled", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            return consumerConfig;
        }
    }
}
