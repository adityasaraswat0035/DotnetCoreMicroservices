using Confluent.Kafka;
using mango.integration.kafka.Configuration;
using mango.integration.kafka.Contract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mango.integration.kafka.Consumer
{
    public abstract class KafkaConsumer<T> : BackgroundService, IKafkaConsumer 
    {
        protected ConsumerConfig consumerConfig;
        protected abstract string topicName { get; }
        private IConsumer<Ignore, string> _consumer;
        public KafkaConsumer(IOptions<KafkaConsumerConfiguration> options)
        {
            consumerConfig = options.Value.Get();
        }
        protected abstract Task ProcessMessage(T deserialiezedObject);

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            using (IAdminClient admin = new AdminClientBuilder(new AdminClientConfig() { BootstrapServers = consumerConfig.BootstrapServers }).Build())
            {
                Metadata brokerMetaData = admin.GetMetadata(TimeSpan.FromMinutes(20));
                List<TopicMetadata> topics = brokerMetaData.Topics;
                _ = topics.Where(x => x.Topic == topicName).FirstOrDefault() ?? throw new ApplicationException("Topic Does not exists");
            }
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
            _consumer.Subscribe(topicName);
            await base.StartAsync(cancellationToken);
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumerResult = _consumer.Consume(stoppingToken);
                    await ProcessMessage(JsonConvert.DeserializeObject<T>(consumerResult.Message.Value));
                }
                catch (Exception ex)
                {
                    //log messages or send to sink  
                }
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _consumer.Unsubscribe();
            _consumer.Close();
            await base.StopAsync(cancellationToken);
        }
    }
}
