using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TopicAttribute:Attribute
    {
        public string Name { get; set; }
    }
}
