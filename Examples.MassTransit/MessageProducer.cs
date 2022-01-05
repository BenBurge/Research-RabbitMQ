using Examples.MassTransit.Models;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.MassTransit
{
    public class MessageProducer : BackgroundService
    {
        private readonly ILogger<MessageProducer> _Logger;
        private readonly IBus _Bus;

        public MessageProducer(ILogger<MessageProducer> logger, IBus bus)
        {
            this._Logger = logger;
            this._Bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _Bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now.UtcDateTime}"});

                _Logger.LogInformation("Published new message.");
                await Task.Delay(2000);
            }
        }
    }
}
