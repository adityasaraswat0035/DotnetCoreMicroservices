using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka.Contract
{
    public interface IKafkaProducer
    {
        public Task<bool> SendMessage(string topic, IMessage message);
    }
}
