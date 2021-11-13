using MassTransit;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadListMicroservices.Consumers
{
    public class ReadListConsumers : IConsumer<List<Person>>
    {
        public async Task Consume(ConsumeContext<List<Person>> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent: {context.Message}");
            var data = context.Message;
        }
    }
}
