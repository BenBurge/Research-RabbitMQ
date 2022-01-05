using Examples.MassTransit.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.MassTransit
{
    public class MessageConsumer : IConsumer<Message>
    {
        public MessageConsumer()
        {

        }

        public Task Consume(ConsumeContext<Message> context)
        {
            Console.WriteLine($"Received {context.Message.Text}");

            return Task.CompletedTask;
        }
    }
}
