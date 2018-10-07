using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaProducer
{
    class Program
    {
        private const int MillisecondsTimeout = 100;

        static void Main(string[] args)
        {
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:9092" }
            }; 

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                string text = null;

                while (text != "exit")
                {
                text = Console.ReadLine();                                                                                                                                                              
                producer.ProduceAsync("hello-topic", null, text);
                }

                producer.Flush(MillisecondsTimeout);
            }
        }
    }
}
