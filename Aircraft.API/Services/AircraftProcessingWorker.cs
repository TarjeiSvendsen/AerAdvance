using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AerAdvance.AircraftApi.Services;

public class AircraftProcessingWorker(IConnection connection): BackgroundService
{


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IChannel channel = await connection.CreateChannelAsync(cancellationToken:stoppingToken);
        await channel.QueueDeclareAsync(queue: "aircraft-manufacture", durable: true, exclusive: false, autoDelete: false,
            arguments: new Dictionary<string, object?> { { "x-queue-type", "quorum" } }, cancellationToken: stoppingToken);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync("aircraft-manufacture", autoAck: true, consumer: consumer, cancellationToken: stoppingToken);
    }
    
}