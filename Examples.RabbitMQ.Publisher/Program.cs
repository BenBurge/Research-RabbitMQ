using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };

using var mqConnection = factory.CreateConnection();
using var mqChannel = mqConnection.CreateModel();

mqChannel.QueueDeclare(queue: "hello-world",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

for(int i = 0; i < 5; i++)
{
    string message = $"Hello, Queue # {i}!";

    var body = Encoding.UTF8.GetBytes(message);

    mqChannel.BasicPublish(exchange: "",
    routingKey: "hello-world",
    basicProperties: null,
    body: body);

    Console.WriteLine($"Sent {message}");

    Thread.Sleep(2000);
}

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();