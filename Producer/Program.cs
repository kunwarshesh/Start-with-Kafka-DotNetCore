using Producer.Implementations;
using System;
using System.Threading.Tasks;

namespace Producer
{
    public class Program
    {
        private const string topic = "kafka-sample";
        public static async Task Main(string[] args)
        {
            Console.Title = "Kafka Sample Producer";
            Console.WriteLine("Kafka Sample Producer");
            Console.WriteLine("Enter your message. Enter q for quitting...");
            string message;
            while ((message = Console.ReadLine()) != "q")
            {
                var producer = new SampleProducer();
                await producer.PublishAsync(topic, message);
            }
        }
    }
}
