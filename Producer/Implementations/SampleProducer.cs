using Confluent.Kafka;
using Producer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Implementations
{
    public class SampleProducer: IProducer
    {
        public async Task<string> PublishAsync(string topic, string message)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            using (var p = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                var messg = new Message<string, string> {Key = null, Value = message };
                DeliveryResult<string, string> a = await p.ProduceAsync(topic, messg);
                return a.Key;
            }
        }
    }
}
