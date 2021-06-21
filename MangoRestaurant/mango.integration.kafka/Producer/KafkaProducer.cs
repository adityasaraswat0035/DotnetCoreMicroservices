using Confluent.Kafka;
using mango.integration.kafka.Configuration;
using mango.integration.kafka.Contract;
using mango.integration.kafka.Exceptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka
{
    public class KafkaProducer : IProducer
    {
        private readonly ProducerConfig producerConfig;
        private static IDictionary<string, TopicMetadata> topicMap = new Dictionary<string, TopicMetadata>();
        private static object _key = new object();

        public KafkaProducer(IOptions<KafkaConfiguration> kafkaConfiguration)
        {
            this.producerConfig = new ProducerConfig()
            {
                BootstrapServers = kafkaConfiguration?.Value.BootstrapServers
            };
            LoadAllTopic(new AdminClientConfig()
            {
                BootstrapServers = kafkaConfiguration?.Value.BootstrapServers
            });
        }

        public async Task<bool> SendMessage(string topicName, IMessage message)
        {

            try
            {
                if (topicMap.ContainsKey(topicName))
                {
                    var serializedMessage = JsonConvert.SerializeObject(message);
                    using (var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
                    {
                        await producer.ProduceAsync(topicName, new Message<Null, string>()
                        {
                            Value = serializedMessage,
                            Timestamp = new Timestamp(DateTime.Now)
                        });
                        return true;
                    }
                }
                else
                {
                    throw new TopicDoesNotExistException(topicName);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void LoadAllTopic(AdminClientConfig adminConfig)
        {
            if (topicMap.Count == 0)
            {
                lock (_key)
                {
                    if (topicMap.Count == 0)
                    {
                        using (IAdminClient admin = new AdminClientBuilder(adminConfig).Build())
                        {
                            Metadata brokerMetaData = admin.GetMetadata(TimeSpan.FromMinutes(5));
                            List<TopicMetadata> topics = brokerMetaData.Topics;
                            foreach (var topic in topics)
                            {
                                topicMap.Add(topic.Topic, topic);
                            }
                        }
                    }
                }
            }
        }
    }
}
