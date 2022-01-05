using Examples.MassTransit;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using MicrosoftHost = Microsoft.Extensions.Hosting;

using MicrosoftHost.IHost host = MicrosoftHost.Host.CreateDefaultBuilder(args)
    .ConfigureLogging((_, logging) =>
    {
        logging.ClearProviders();
        logging.AddSimpleConsole(options =>
        {
            options.IncludeScopes = true;
        });
    })
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

        services.AddHostedService<MessageProducer>();
        services.AddHostedService<OtherMessageProducer>();
    })
    .Build();



await host.RunAsync();