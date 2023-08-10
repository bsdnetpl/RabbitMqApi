using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqApi.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {

            var factory = new ConnectionFactory();
     
            factory.HostName = "10.0.0.15";
            //factory.Port = 15672;
            factory.UserName = "adi";
            factory.Password = "123!@#";
            factory.VirtualHost = "/";

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("product", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "product", body: body);
        }
    }
}
