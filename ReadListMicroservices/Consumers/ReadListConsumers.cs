using MassTransit;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ReadListMicroservices.Consumers
{
    public class ReadListConsumers : IConsumer<Person[]>
    {
        //Read the data that send by Consume
        public async Task Consume(ConsumeContext<Person[]> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent: {context.Message}");
            var data = context.Message;
            Debug.WriteLine(data);
            Console.WriteLine(data);
        }
    }
}
