using System;
using RabbitMQ.Client;
using System.Text;
using Catalog_Service_BLL;

namespace MessagingClient
{
    public class Send
    {
        public void SendMessage(Item item)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ItemChangeNotification",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = item.ToString();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "ItemChangeNotification",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
