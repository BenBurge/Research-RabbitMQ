using Examples.MassTransit;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicrosoftHost = Microsoft.Extensions.Hosting;

using MicrosoftHost.IHost host = MicrosoftHost.Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<MessageConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddMassTransitHostedService();

        services.AddHostedService<Worker>();
    })
    .Build();



await host.RunAsync();