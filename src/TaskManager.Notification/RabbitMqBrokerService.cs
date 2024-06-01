using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace TaskManager.Notification;

public class RabbitMqBrokerService(IConfiguration configuration) : IRabbitMqBroker
{
    private IModel GetChanell()
    {
        var factory = new ConnectionFactory
        {
            HostName = configuration["RabbitMq:HostName"],
            DispatchConsumersAsync = true
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        return channel;
    }

    public void Publish(Message message)
    {
        var channel = GetChanell();

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: configuration["RabbitMq:Queue"],
             body: body);
    }
}