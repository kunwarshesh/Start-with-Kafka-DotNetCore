using Confluent.Kafka;
using Consumer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer.Implementations
{
    public class SampleConsumer: IConsumer
    {
        public Task SubscribeAsync(string topic, Action<string> message)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "localhost:9092"
            };

            using (var cons = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
            {
                cons.Subscribe(topic);
                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    while (true)
                        try
                        {
                            var cr = cons.Consume(cts.Token);
                            message(cr.Message.Value);
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine(e);
                        }
                }
                catch (Exception)
                {
                    cons.Close();
                }
            }

            return Task.CompletedTask;
        }
    }
}