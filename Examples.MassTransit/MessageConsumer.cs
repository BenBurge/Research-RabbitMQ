using Examples.MassTransit.Models;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.MassTransit
{
    public class MessageConsumer : IConsumer<Message>
    {
        private readonly ILogger<MessageConsumer> _Logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            this._Logger = logger;
        }

        public Task Consume(ConsumeContext<Message> context)
        {
            context.AddConsumeTask(DoConsumeThing());
            _Logger.LogInformation($"Received new message: {context.Message.Text}");

            return Task.CompletedTask;
        }

        private Task DoConsumeThing()
        {
            _Logger.LogInformation("Did a thing before ack.");

            return Task.CompletedTask;
        }
    }
}
