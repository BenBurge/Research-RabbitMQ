using Examples.MassTransit.Models;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.MassTransit
{
    public class Worker : BackgroundService
    {
        private readonly IBus _Bus;

        public Worker(IBus bus)
        {
            this._Bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _Bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now.UtcDateTime}"});

                await Task.Delay(2000);
            }
        }
    }
}
