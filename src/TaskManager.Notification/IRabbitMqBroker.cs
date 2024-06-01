namespace TaskManager.Notification;

public interface IRabbitMqBroker
{
    void Publish(Message message);
}