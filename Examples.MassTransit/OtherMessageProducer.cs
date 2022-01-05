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
    public class OtherMessageProducer : BackgroundService
    {
        private readonly ILogger<OtherMessageProducer> _Logger;
        private readonly IBus _Bus;

        public OtherMessageProducer(ILogger<OtherMessageProducer> logger, IBus bus)
        {
            _Logger = logger;
            _Bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _Bus.Publish(new Message
                {
                    Text = $"The time in 5 minutes is {DateTimeOffset.Now.UtcDateTime.AddMinutes(5)}"
                });

                _Logger.LogInformation("Published new message.");

                var rnd = new Random();
                await Task.Delay(1000 * rnd.Next(5, 10));
            }
        }
    }
}
