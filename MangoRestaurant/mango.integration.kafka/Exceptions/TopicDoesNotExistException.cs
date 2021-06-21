using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka.Exceptions
{
    public class TopicDoesNotExistException:Exception
    {
        public TopicDoesNotExistException(String topicName):base($"{topicName} does not exists")
        {

        }
        public TopicDoesNotExistException(String topicName,Exception innerException) : base($"{topicName} does not exists", innerException)
        {

        }
    }
}
