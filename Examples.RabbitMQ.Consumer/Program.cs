using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var mqConnection = factory.CreateConnection();
using var mqChannel = mqConnection.CreateModel();

mqChannel.QueueDeclare(queue: "hello-world",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var mqConsumer = new EventingBasicConsumer(mqChannel);

mqConsumer.Received += (model, e) =>
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Received {message}");
};

mqChannel.BasicConsume(queue: "hello-world",
    autoAck: true,
    consumer: mqConsumer);

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();