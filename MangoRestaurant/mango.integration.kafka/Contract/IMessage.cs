using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.integration.kafka.Contract
{
    //for now it will act as marker interface
    public interface IMessage
    {
        public string MessageId => Guid.NewGuid().ToString();
    }
}
