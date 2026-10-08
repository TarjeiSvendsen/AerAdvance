using System.Text;
using RabbitMQ.Client;

namespace AerAdvance.LobbyApi.Services;

public class AircraftCreationWorker(IConnection connection):BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IChannel channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);
        await channel.QueueDeclareAsync(queue: "aircraft-manufacture", durable: true, exclusive: false, autoDelete: false,
            arguments: new Dictionary<string, object?> { { "x-queue-type", "quorum" } }, cancellationToken: stoppingToken);

        for (int i = 0; i < 10; i++)
        {
            const string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "aircraft-manufacture", body: body, cancellationToken: stoppingToken);
            Console.WriteLine($" [x] Sent {message}");
            Thread.Sleep(100);
        }
        
        
    }
}