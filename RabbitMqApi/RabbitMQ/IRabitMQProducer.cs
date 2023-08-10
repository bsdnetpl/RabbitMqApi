namespace RabbitMqApi.RabbitMQ
{
    public interface IRabitMQProducer
    {
        void SendProductMessage<T>(T message);
    }
}