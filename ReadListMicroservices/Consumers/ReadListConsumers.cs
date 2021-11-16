using MassTransit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ReadListMicroservices.Consumers
{
    public class ReadListConsumers : IConsumer<Person[]>
    {
        public async Task Consume(ConsumeContext<Person[]> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent: {context.Message}");
            var data = context.Message;
            Debug.WriteLine(data);
            Console.WriteLine(data);
        }
    }
}
